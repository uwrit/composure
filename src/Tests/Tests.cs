using System;
using System.Linq;
using Composure;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Basic_Query_Works()
        {
            // Columns
            var name = new Column("Name");
            var category = new Column("Category");
            var deliciousness = new Column("Deliciousness");

            // Get query
            var query = new NamedSet
            {
                Select = new[] { name, category, deliciousness },
                From = "dbo.Food",
                Where = new[]
                {
                    deliciousness > 3,
                    category == "fruit"
                }
            };

            // 3 Columns
            Assert.Equal(3, query.Select.Count());

            // Columns not aliased
            Assert.DoesNotContain(".", name.ToString());

            // Quotes added, column eval returns as expected
            Assert.Equal("Category = 'fruit'", query.Where.ElementAt(1).ToString());
        }

        [Fact]
        public void Join_Group_By_Works()
        {
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
                Select =  new ISelectable[] { categoryId, categoryName, totalCount, maxDeliciousness },
                From =    new[] { j1, j2 },
                Where =   new[] { deliciousness > 3 },
                GroupBy = new[] { categoryId, categoryName },
                Having =  new[] { calcMaxDeliciousness >= 5 },
                OrderBy = new[] { categoryName }
            };

            var sql = query.ToString();

            Assert.NotEmpty(sql);
        }
    }
}
