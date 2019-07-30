# Composure
**Composure** is a simple SQL-authoring library for .NET. Composure allows for statically-typed SQL-like query syntax directly in C#, with minimal messy string manipulation. Composure is designed for readability, clarity, and testability, and was developed for the [Leaf Clinical Data Explorer app](https://github.com/uwrit/leaf) at the [University of Washington](http://www.washington.edu/) by Nic Dobbins [@ndobb](https://github.com/ndobb) and Cliff Spital [@cspital](https://github.com/cspital).

**Note: If you are able to create and use Stored Procedures, Views, and other SQL objects, please read no further and do so!** 

> In addition to certain performance gains and so on, precompiled SQL drastically reduces the risk of [SQL injection](https://en.wikipedia.org/wiki/SQL_injection) and other security concerns related to dynamically creating queries. It also allows separation of database and app code, often making for cleaner, more maintainable code bases.

Also note that **Composure is *not*** an object-relational-mapper, and doesn't handle SQL connections or execute queries itself. Libraries such as [Dapper](https://stackexchange.github.io/Dapper/) do a great job of that already. 

Rather, **Composure** allows you to reason about complex SQL queries in an object-oriented, visually intuition fashion using a simple domain-specific-language and operators. Let's get started!

## Installation
Load from Nuget via the `dotnet CLI`:
```bash
$ dotnet add package Composure --version 1.0.0
```
or build locally:
```bash
$ git clone https://github.com/uwrit/composure.git
$ cd composure/src/Composure
$ dotnet build -c Release

# Outputs dll to /bin/Release/netcoreapp2.2/
```

- [Basic SELECT from a table/view](#basic-select-from-a-tableview)
- [Nested WHERE conditions](#nested-where-conditions)
- [Basic JOIN](#basic-join)
- [JOIN and GROUP BY](#join-and-group-by)
- [UNION and wrap as subquery](#union-and-wrap-as-subquery)
- [CASE WHEN statements](#case-when-statements)
- [Using inheritance for predefined sets and intellisense](#using-inheritance-for-predefined-sets-and-intellisense)
- [Query Syntax cheat-sheet](#query-syntax-cheat-sheet)
- [Caveats](#caveats)

## Basic SELECT from a table/view
```c#
// Columns
var name = new Column("Name");
var category = new Column("Category");
var deliciousness = new Column("Deliciousness");

// Get query
var query = new NamedSet
{
    Select = new[] { name, category, deliciousness },
    From   = "dbo.Food",
    Where  = new[]
    {
        deliciousness > 3,
        category == "fruit"
    }
};

query.ToString();
```
Returns:
```sql
SELECT 
    Name
  , Category
  , Deliciousness 
FROM 
    dbo.Food 
WHERE 
    Deliciousness > 3 
    AND Category = 'fruit'
```
And that's it! Note that these examples show formatted SQL only for readability. Composure itself does **not** beautify SQL. 

Let's try a more interesting example.

## Nested WHERE conditions
```c#
// WHERE clause conditions
var isDelicious = deliciousness > 3;
var isFruit = category == "fruit";

// Get query
var query = new NamedSet
{
    Select = new[] { name, category, deliciousness },
    From   = "dbo.Food",
    Where  = new[] { (isDelicious & !isFruit) | isFruit }
};

query.ToString();
```
Returns:
```sql
SELECT 
    Name
  , Category
  , Deliciousness
FROM 
    dbo.Food 
WHERE 
    (
        (Deliciousness > 3 AND NOT (Category = 'fruit')) OR
         Category = 'fruit'
    )
```
At this point if you are thinking the above is readable and clear, great! If however the above syntax looks like voodoo, that's okay too! **Composure** is strongly typed, and leverages [operator overloading](https://en.wikipedia.org/wiki/Operator_overloading) to allow for concise, simple code, that compiles to plain ol' SQL.

Note that we could have just as easily written the above as:
```c#
var isDelicious = new ColumnEval(deliciousness, EvaluationType.GreaterThan, new Expression(3));
var isFruit = new ColumnEval(category, EvaluationType.Equal, newQuotedExpression("fruit"));

// Get query
var query = new NamedSet
{
    Select = new ISelectable[] { name, category, deliciousness },
    From = new RawSet("dbo.Food"),
    Where = new IEvaluatable[]
    {
        new OrEval
        (
            new AndEval(isDelicious, new NotEval(isFruit)),
            isFruit
        )
    }
};
```
...and the resulting SQL would have been identical. **Composure** supports both the shorthand and longhand query syntax, so choose the style that works best for you.

Skip to the [Query Syntax cheat-sheet](#query-syntax-cheat-sheet) below for a quick reference.

## Basic JOIN
```c#
// Sets
var set1 = new RawSet("dbo.Food");
var set2 = new RawSet("dbo.Category");

// Joins
var j1 = new Join { Set = set1, Alias = "F" };
var j2 = new Join
{
    Set = set2,
    Alias = "C",
    Type = JoinType.Inner,
    On = new[] { new Column("CategoryId", j1) == new Column("CategoryId") }
};

// Columns with Sets specified
var name = new Column("Name", j1);
var deliciousness = new Column("Deliciousness", j1);
var categoryName = new Column("CategoryName", j2);

// Get query
var query = new JoinedSet
{
    Select  = new[] { name, deliciousness, categoryName },
    From    = new[] { j1, j2 },
    OrderBy = new[] { categoryName, name }
};

query.ToString();
```
Returns:
```sql
SELECT 
    F.Name
  , F.Deliciousness
  , C.CategoryName 
FROM 
    dbo.Food AS F 
        INNER JOIN 
    dbo.Category AS C 
        ON F.CategoryId = C.CategoryId    
ORDER BY 
    C.CategoryName
  , F.Name
```

## JOIN and GROUP BY
```c#
// Sets
var set1 = new RawSet("dbo.Food");
var set2 = new RawSet("dbo.Category");

// Joins
var j1 = new Join { Set = set1, Alias = "F" };
var j2 = new Join
{
    Set = set2,
    Alias = "C",
    Type = JoinType.Inner,
    On = new[] { new Column("CategoryId", j1) == new Column("CategoryId") }
};

// Columns with Sets specified
var categoryId = new Column("CategoryId", j2);
var categoryName = new Column("CategoryName", j2);
var deliciousness = new Column("Deliciousness", j1);

// Aggregation expressions
var calcMaxDeliciousness = new Expression($"MAX({deliciousness})");
var calcTotalCount = new Expression("COUNT(*)");

// Aggregate columns
var totalCount = new ExpressedColumn("TotalCount", calcTotalCount);
var maxDeliciousness = new ExpressedColumn("MaxDeliciousness", calcMaxDeliciousness);

// Get query
var query = new JoinedSet
{
    Select  = new[] { categoryId, categoryName, totalCount, maxDeliciousness },
    From    = new[] { j1, j2 },
    Where   = new[] { deliciousness > 3 },
    GroupBy = new[] { categoryId, categoryName },
    Having  = new[] { calcMaxDeliciousness >= 5 },
    OrderBy = new[] { categoryName }
};

query.ToString();
```
Returns:
```sql
SELECT 
    C.CategoryId
  , C.CategoryName
  , COUNT(*) AS TotalCount
  , MAX(F.Deliciousness) AS MaxDeliciousness 
FROM 
    dbo.Food AS F 
        INNER JOIN 
    dbo.Category AS C 
        ON F.CategoryId = C.CategoryId 
WHERE 
    F.Deliciousness > 3 
GROUP BY 
    C.CategoryId 
  , C.CategoryName 
HAVING 
    MAX(F.Deliciousness) >= 5 
ORDER BY 
    C.CategoryName
```

## UNION and wrap as subquery
```c#
// Columns
var allColumns = new[] { "Name", "Category", "Deliciousness" };

// Reusable function to get columns for each set
var getColumns() => allColumns.Select(c => new Column(c)).ToArray();

// Sets
var set1 = new NamedSet { Select = getColumns(), From = "dbo.Food", Alias = "F" };
var set2 = new NamedSet { Select = getColumns(), From = "dbo.Beverage", Alias = "B" };

// Union
var union = new UnionedSet { set1, set2 };

// Get wrapper query
var wrapper = new VirtualSet { Select = getColumns(), From = union, Alias = "W" };

wrapper.ToString();
```
Returns:
```sql
SELECT 
    W.Name
  , W.Category
  , W.Deliciousness 
FROM 
     (SELECT F.Name
           , F.Category
           , F.Deliciousness 
      FROM dbo.Food AS F 
      UNION 
      SELECT B.Name
           , B.Category
           , B.Deliciousness 
      FROM dbo.Beverage AS B) AS W
```

## CASE WHEN statements
```c#
// Columns
var name = new Column("Name");
var category = new Column("Category");
var deliciousness = new Column("Deliciousness");

// Cases
var isDelicious = deliciousness > 3;
var isFruit = category == "fruit";
var isVeggie = category == "vegetable";

// Case when
var foodCases = new CaseWhen
{
    Cases = new[]
    {
        isFruit                | "It's a fruit",
        isDelicious & isVeggie | "It's delicious and a vegetable",
        isVeggie               | "It's a vegetable, but not delicious",
        isDelicious            | "It's something else delicious"
    },
    Else = new QuotedExpression("It's something else and not delicious!")
};

// Get query
var query = new NamedSet
{
    Select = new[] { name, new ExpressedColumn("FoodCases", foodCases) },
    From   = "dbo.Food",
};

query.ToString();
```
Returns:
```sql
SELECT 
    Name
  , Category
  , CASE 
         WHEN Category = 'fruit' THEN 'It''s a fruit' 
         WHEN (Deliciousness > 3 AND Category = 'vegetable') THEN 'It''s delicious and a vegetable' 
         WHEN Category = 'vegetable' THEN 'It''s a vegetable, but not delicious' 
         WHEN Deliciousness > 3 THEN 'It''s something else delicious' 
         ELSE 'It''s something else and not delicious!' 
    END AS FoodCases 
FROM 
    dbo.Food
```

## Using inheritance for predefined sets and intellisense
```c#
public class FoodsAndCategoriesSet : JoinedSet
{
    public readonly Column FoodName;
    public readonly Column CategoryId;
    public readonly Column CategoryName;
    public readonly Column Deliciousness;

    // Predefine JOINs on initialization
    public FoodsAndCategoriesSet()
    {
        // Sets
        var foods = new RawSet("dbo.Food");
        var categories = new RawSet("dbo.Category");

        // Joins
        var j1 = new Join { Set = foods, Alias = "F" };
        var j2 = new Join
        {
            Set = categories,
            Alias = "C",
            Type = JoinType.Left,
            On = new[] { new Column("CategoryId", j1) == new Column("CategoryId") }
        };

        // Columns
        FoodName = new Column("Name", j1);
        CategoryId = new Column("CategoryId", j2);
        CategoryName = new Column("CategoryName", j2);
        Deliciousness = new Column("Deliciousness", j1);

        // Final joined Sets
        From = new[] { j1, j2 };
    }
}
```
The joined `FoodsAndCategoriesSet` is now conveniently predefined and wrapped in class,
so its columns can be used as statically-typed properties with full intellisense support.
```c#
// Initialize joined set
var q = new FoodsAndCategoriesSet();

q.Select = new[] { q.FoodName, q.CategoryName, q.Deliciousness };
q.Where = new[]
{
    q.Deliciousness > 3,
    q.CategoryName == new[] { "vegetable", "fruit" }
};
q.OrderBy = new[] { q.CategoryName };

q.ToString();
```
Returns:
```sql
SELECT 
    F.Name
  , C.CategoryName
  , F.Deliciousness 
FROM 
    dbo.Food AS F 
        LEFT JOIN 
    dbo.Category AS C 
        ON F.CategoryId = C.CategoryId 
WHERE 
    F.Deliciousness > 3 
    AND C.CategoryName IN ('vegetable', 'fruit' )  
ORDER BY 
    C.CategoryName
```

# Query Syntax cheat-sheet
```c#
 deliciousness > 3                               // Deliciousness > 3
 deliciousness == 3 & 5                          // Deliciousness BETWEEN 3 AND 5
 !(deliciousness == 2)                           // NOT (Deliciousness = 2)
 name == "apple" & category == "fruit"           // (Name = 'apple' AND Category = 'fruit')
 name == new[] { "apple", "banana" }             // Name IN ('apple', 'banana')
 name != new[] { "hotdog", "sauce" }             // Name NOT IN ('hotdog', 'sauce') 

 new CaseWhen
 {
     Cases = new[]               
     {                                           // CASE 
         deliciousness > 5  | "Super delicious", //      WHEN Deliciousness > 5  THEN 'Super delicious'
         deliciousness <= 4 | "So so"            //      WHEN Deliciousness <= 4 THEN 'So so'
     },                                          //
     Else = new QuotedExpression("Not yummy")    //      ELSE 'Not yummy'           
 }                                               // END
```