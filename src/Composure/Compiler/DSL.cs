using System;
using System.Collections.Generic;

namespace Composure
{
    #region CaseWhen
    public partial class CaseWhen
    {
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();

        // CASE / WHEN | String
        public static ExpressionEval operator ==(CaseWhen caseWhen, string val) => new ExpressionEval(caseWhen, EvalType.Equal, new QuotedExpression(val));
        public static ExpressionEval operator !=(CaseWhen caseWhen, string val) => new ExpressionEval(caseWhen, EvalType.NotEqual, new QuotedExpression(val));

        // CASE / WHEN | Int
        public static ExpressionEval operator ==(CaseWhen caseWhen, int val) => new ExpressionEval(caseWhen, EvalType.Equal, new Expression(val));
        public static ExpressionEval operator !=(CaseWhen caseWhen, int val) => new ExpressionEval(caseWhen, EvalType.NotEqual, new Expression(val));

        // CASE / WHEN | Double
        public static ExpressionEval operator ==(CaseWhen caseWhen, double val) => new ExpressionEval(caseWhen, EvalType.Equal, new Expression(val));
        public static ExpressionEval operator !=(CaseWhen caseWhen, double val) => new ExpressionEval(caseWhen, EvalType.NotEqual, new Expression(val));
    }
    #endregion

    #region Column
    public partial class Column
    {
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();

        // Column | Column
        public static ColumnsEval operator ==(Column col1, Column col2) => new ColumnsEval(col1, EvalType.Equal, col2);
        public static ColumnsEval operator !=(Column col1, Column col2) => new ColumnsEval(col1, EvalType.NotEqual, col2);
        public static ColumnsEval operator >=(Column col1, Column col2) => new ColumnsEval(col1, EvalType.GreaterThanOrEqualTo, col2);
        public static ColumnsEval operator >(Column col1, Column col2) => new ColumnsEval(col1, EvalType.GreaterThan, col2);
        public static ColumnsEval operator <=(Column col1, Column col2) => new ColumnsEval(col1, EvalType.LessThanOrEqualTo, col2);
        public static ColumnsEval operator <(Column col1, Column col2) => new ColumnsEval(col1, EvalType.LessThan, col2);

        // Column | Expression
        public static ColumnEval operator ==(Column col, IExpression exp) => new ColumnEval(col, EvalType.Equal, exp);
        public static ColumnEval operator !=(Column col, IExpression exp) => new ColumnEval(col, EvalType.NotEqual, exp);
        public static ColumnEval operator >=(Column col, IExpression exp) => new ColumnEval(col, EvalType.GreaterThanOrEqualTo, exp);
        public static ColumnEval operator >(Column col, IExpression exp) => new ColumnEval(col, EvalType.GreaterThan, exp);
        public static ColumnEval operator <=(Column col, IExpression exp) => new ColumnEval(col, EvalType.LessThanOrEqualTo, exp);
        public static ColumnEval operator <(Column col, IExpression exp) => new ColumnEval(col, EvalType.LessThan, exp);

        // Expression | Column
        public static ColumnEval operator ==(IExpression exp, Column col) => new ColumnEval(exp, EvalType.Equal, col);
        public static ColumnEval operator !=(IExpression exp, Column col) => new ColumnEval(exp, EvalType.NotEqual, col);
        public static ColumnEval operator >=(IExpression exp, Column col) => new ColumnEval(exp, EvalType.GreaterThanOrEqualTo, col);
        public static ColumnEval operator >(IExpression exp, Column col) => new ColumnEval(exp, EvalType.GreaterThan, col);
        public static ColumnEval operator <=(IExpression exp, Column col) => new ColumnEval(exp, EvalType.LessThanOrEqualTo, col);
        public static ColumnEval operator <(IExpression exp, Column col) => new ColumnEval(exp, EvalType.LessThan, col);

        // Column | Int
        public static ColumnEval operator ==(Column col, int val) => new ColumnEval(col, EvalType.Equal, new Expression(val));
        public static ColumnEval operator !=(Column col, int val) => new ColumnEval(col, EvalType.NotEqual, new Expression(val));
        public static ColumnEval operator >=(Column col, int val) => new ColumnEval(col, EvalType.GreaterThanOrEqualTo, new Expression(val));
        public static ColumnEval operator >(Column col, int val) => new ColumnEval(col, EvalType.GreaterThan, new Expression(val));
        public static ColumnEval operator <=(Column col, int val) => new ColumnEval(col, EvalType.LessThanOrEqualTo, new Expression(val));
        public static ColumnEval operator <(Column col, int val) => new ColumnEval(col, EvalType.LessThan, new Expression(val));

        // Int | Column
        public static ColumnEval operator ==(int val, Column col) => new ColumnEval(new Expression(val), EvalType.Equal, col);
        public static ColumnEval operator !=(int val, Column col) => new ColumnEval(new Expression(val), EvalType.NotEqual, col);
        public static ColumnEval operator >=(int val, Column col) => new ColumnEval(new Expression(val), EvalType.GreaterThanOrEqualTo, col);
        public static ColumnEval operator >(int val, Column col) => new ColumnEval(new Expression(val), EvalType.GreaterThan, col);
        public static ColumnEval operator <=(int val, Column col) => new ColumnEval(new Expression(val), EvalType.LessThanOrEqualTo, col);
        public static ColumnEval operator <(int val, Column col) => new ColumnEval(new Expression(val), EvalType.LessThan, col);

        // Column | Double
        public static ColumnEval operator ==(Column col, double val) => new ColumnEval(col, EvalType.Equal, new Expression(val));
        public static ColumnEval operator !=(Column col, double val) => new ColumnEval(col, EvalType.NotEqual, new Expression(val));
        public static ColumnEval operator >=(Column col, double val) => new ColumnEval(col, EvalType.GreaterThanOrEqualTo, new Expression(val));
        public static ColumnEval operator >(Column col, double val) => new ColumnEval(col, EvalType.GreaterThan, new Expression(val));
        public static ColumnEval operator <=(Column col, double val) => new ColumnEval(col, EvalType.LessThanOrEqualTo, new Expression(val));
        public static ColumnEval operator <(Column col, double val) => new ColumnEval(col, EvalType.LessThan, new Expression(val));

        // Double | Column
        public static ColumnEval operator ==(double val, Column col) => new ColumnEval(new Expression(val), EvalType.Equal, col);
        public static ColumnEval operator !=(double val, Column col) => new ColumnEval(new Expression(val), EvalType.NotEqual, col);
        public static ColumnEval operator >=(double val, Column col) => new ColumnEval(new Expression(val), EvalType.GreaterThanOrEqualTo, col);
        public static ColumnEval operator >(double val, Column col) => new ColumnEval(new Expression(val), EvalType.GreaterThan, col);
        public static ColumnEval operator <=(double val, Column col) => new ColumnEval(new Expression(val), EvalType.LessThanOrEqualTo, col);
        public static ColumnEval operator <(double val, Column col) => new ColumnEval(new Expression(val), EvalType.LessThan, col);

        // Column | Decimal
        public static ColumnEval operator ==(Column col, decimal val) => new ColumnEval(col, EvalType.Equal, new Expression(val));
        public static ColumnEval operator !=(Column col, decimal val) => new ColumnEval(col, EvalType.NotEqual, new Expression(val));
        public static ColumnEval operator >=(Column col, decimal val) => new ColumnEval(col, EvalType.GreaterThanOrEqualTo, new Expression(val));
        public static ColumnEval operator >(Column col, decimal val) => new ColumnEval(col, EvalType.GreaterThan, new Expression(val));
        public static ColumnEval operator <=(Column col, decimal val) => new ColumnEval(col, EvalType.LessThanOrEqualTo, new Expression(val));
        public static ColumnEval operator <(Column col, decimal val) => new ColumnEval(col, EvalType.LessThan, new Expression(val));

        // Decimal | Column
        public static ColumnEval operator ==(decimal val, Column col) => new ColumnEval(new Expression(val), EvalType.Equal, col);
        public static ColumnEval operator !=(decimal val, Column col) => new ColumnEval(new Expression(val), EvalType.NotEqual, col);
        public static ColumnEval operator >=(decimal val, Column col) => new ColumnEval(new Expression(val), EvalType.GreaterThanOrEqualTo, col);
        public static ColumnEval operator >(decimal val, Column col) => new ColumnEval(new Expression(val), EvalType.GreaterThan, col);
        public static ColumnEval operator <=(decimal val, Column col) => new ColumnEval(new Expression(val), EvalType.LessThanOrEqualTo, col);
        public static ColumnEval operator <(decimal val, Column col) => new ColumnEval(new Expression(val), EvalType.LessThan, col);

        // Column | String
        public static ColumnEval operator ==(Column col, string val) => new ColumnEval(col, EvalType.Equal, new QuotedExpression(val));
        public static ColumnEval operator !=(Column col, string val) => new ColumnEval(col, EvalType.NotEqual, new QuotedExpression(val));
        public static ColumnEval operator >=(Column col, string val) => new ColumnEval(col, EvalType.GreaterThanOrEqualTo, new QuotedExpression(val));
        public static ColumnEval operator >(Column col, string val) => new ColumnEval(col, EvalType.GreaterThan, new QuotedExpression(val));
        public static ColumnEval operator <=(Column col, string val) => new ColumnEval(col, EvalType.LessThanOrEqualTo, new QuotedExpression(val));
        public static ColumnEval operator <(Column col, string val) => new ColumnEval(col, EvalType.LessThan, new QuotedExpression(val));

        // String | Column
        public static ColumnEval operator ==(string val, Column col) => new ColumnEval(new QuotedExpression(val), EvalType.Equal, col);
        public static ColumnEval operator !=(string val, Column col) => new ColumnEval(new QuotedExpression(val), EvalType.NotEqual, col);
        public static ColumnEval operator >=(string val, Column col) => new ColumnEval(new QuotedExpression(val), EvalType.GreaterThanOrEqualTo, col);
        public static ColumnEval operator >(string val, Column col) => new ColumnEval(new QuotedExpression(val), EvalType.GreaterThan, col);
        public static ColumnEval operator <=(string val, Column col) => new ColumnEval(new QuotedExpression(val), EvalType.LessThanOrEqualTo, col);
        public static ColumnEval operator <(string val, Column col) => new ColumnEval(new QuotedExpression(val), EvalType.LessThan, col);

        // Column | Boolean
        public static ColumnEval operator ==(Column col, bool val) => new ColumnEval(col, EvalType.Equal, new Expression(val ? 1 : 0));
        public static ColumnEval operator !=(Column col, bool val) => new ColumnEval(col, EvalType.NotEqual, new Expression(val ? 1 : 0));

        // Boolean | Column
        public static ColumnEval operator ==(bool val, Column col) => new ColumnEval(new Expression(val ? 1 : 0), EvalType.Equal, col);
        public static ColumnEval operator !=(bool val, Column col) => new ColumnEval(new Expression(val ? 1 : 0), EvalType.NotEqual, col);

        // Column | IEnumerable<String>
        public static ColumnEval operator ==(Column col, IEnumerable<string> vals) => new ColumnEval(col, EvalType.In, new QuotedExpressions(vals));
        public static ColumnEval operator !=(Column col, IEnumerable<string> vals) => new ColumnEval(col, EvalType.NotIn, new QuotedExpressions(vals));

        // IEnumerable<String> | Column
        public static ColumnEval operator ==(IEnumerable<string> vals, Column col) => new ColumnEval(new QuotedExpressions(vals), EvalType.In, col);
        public static ColumnEval operator !=(IEnumerable<string> vals, Column col) => new ColumnEval(new QuotedExpressions(vals), EvalType.NotIn, col);

        // Column | IEnumerable<int>
        public static ColumnEval operator ==(Column col, IEnumerable<int> vals) => new ColumnEval(col, EvalType.In, new Expressions(vals));
        public static ColumnEval operator !=(Column col, IEnumerable<int> vals) => new ColumnEval(col, EvalType.NotIn, new Expressions(vals));

        // IEnumerable<int> | Column
        public static ColumnEval operator ==(IEnumerable<int> vals, Column col) => new ColumnEval(new Expressions(vals), EvalType.In, col);
        public static ColumnEval operator !=(IEnumerable<int> vals, Column col) => new ColumnEval(new Expressions(vals), EvalType.NotIn, col);

        // Column | IEnumerable<double>
        public static ColumnEval operator ==(Column col, IEnumerable<double> vals) => new ColumnEval(col, EvalType.In, new Expressions(vals));
        public static ColumnEval operator !=(Column col, IEnumerable<double> vals) => new ColumnEval(col, EvalType.NotIn, new Expressions(vals));

        // IEnumerable<double> | Column
        public static ColumnEval operator ==(IEnumerable<double> vals, Column col) => new ColumnEval(new Expressions(vals), EvalType.In, col);
        public static ColumnEval operator !=(IEnumerable<double> vals, Column col) => new ColumnEval(new Expressions(vals), EvalType.NotIn, col);

        // Column | IEnumerable<decimal>
        public static ColumnEval operator ==(Column col, IEnumerable<decimal> vals) => new ColumnEval(col, EvalType.In, new Expressions(vals));
        public static ColumnEval operator !=(Column col, IEnumerable<decimal> vals) => new ColumnEval(col, EvalType.NotIn, new Expressions(vals));

        // IEnumerable<decimal> | Column
        public static ColumnEval operator ==(IEnumerable<decimal> vals, Column col) => new ColumnEval(new Expressions(vals), EvalType.In, col);
        public static ColumnEval operator !=(IEnumerable<decimal> vals, Column col) => new ColumnEval(new Expressions(vals), EvalType.NotIn, col);
    }

    public partial class ColumnEval
    {
        public static ColumnRangeEval operator &(ColumnEval eval, IExpression exp) => new ColumnRangeEval(eval.Column, eval.Value, exp, eval.Type == EvalType.Equal);
        public static ColumnRangeEval operator &(ColumnEval eval, int val) => new ColumnRangeEval(eval.Column, eval.Value, val, eval.Type == EvalType.Equal);
        public static ColumnRangeEval operator &(ColumnEval eval, double val) => new ColumnRangeEval(eval.Column, eval.Value, val, eval.Type == EvalType.Equal);
        public static ColumnRangeEval operator &(ColumnEval eval, decimal val) => new ColumnRangeEval(eval.Column, eval.Value, val, eval.Type == EvalType.Equal);
        public static ColumnRangeEval operator &(ColumnEval eval, string val) => new ColumnRangeEval(eval.Column, eval.Value, new QuotedExpression(val), eval.Type == EvalType.Equal);

        // Expression/Number | Column | Expression/Number
        public static ExpressionRangeEval operator &(IExpression exp, ColumnEval eval) => new ExpressionRangeEval(exp, eval.Column, eval.Value);
        public static ExpressionRangeEval operator &(int val, ColumnEval eval) => new ExpressionRangeEval(new Expression(val), eval.Column, eval.Value);
        public static ExpressionRangeEval operator &(double val, ColumnEval eval) => new ExpressionRangeEval(new Expression(val), eval.Column, eval.Value);
        public static ExpressionRangeEval operator &(decimal val, ColumnEval eval) => new ExpressionRangeEval(new Expression(val), eval.Column, eval.Value);
        public static ExpressionRangeEval operator &(string val, ColumnEval eval) => new ExpressionRangeEval(new QuotedExpression(val), eval.Column, eval.Value);

        // WHEN / THEN
        public static WhenThen operator |(ColumnEval eval, IExpression exp) => new WhenThen(eval, exp);
        public static WhenThen operator |(ColumnEval eval, int val) => new WhenThen(eval, new Expression(val));
        public static WhenThen operator |(ColumnEval eval, double val) => new WhenThen(eval, new Expression(val));
        public static WhenThen operator |(ColumnEval eval, decimal val) => new WhenThen(eval, new Expression(val));
        public static WhenThen operator |(ColumnEval eval, string val) => new WhenThen(eval, new QuotedExpression(val));
    }

    public partial class ColumnsEval
    {
        // Column | Column | Column
        public static ColumnRangeEval operator &(ColumnsEval eval, Column column3) => new ColumnRangeEval(eval.Left, eval.Right, column3, eval.Type == EvalType.Equal);

        // Column | Column | IExpression
        public static ColumnRangeEval operator &(ColumnsEval eval, IExpression exp) => new ColumnRangeEval(eval.Left, eval.Right, exp, eval.Type == EvalType.Equal);
    }

    #endregion 

    #region ConditionalEvals

    public abstract partial class Evaluation
    {
        public static AndEval operator &(Evaluation eval1, Evaluation eval2) => new AndEval(eval1, eval2);
        public static AndEval operator &(OrEval eval1, Evaluation eval2) => new AndEval(eval1, eval2);
        public static AndEval operator &(Evaluation eval1, OrEval eval2) => new AndEval(eval1, eval2);
        public static AndEval operator &(AndEval and, Evaluation eval)
        {
            and.Add(eval);
            return and;
        }

        public static OrEval operator |(Evaluation eval1, Evaluation eval2) => new OrEval(eval1, eval2);
        public static OrEval operator |(AndEval eval1, Evaluation eval2) => new OrEval(eval1, eval2);
        public static OrEval operator |(Evaluation eval1, AndEval eval2) => new OrEval(eval1, eval2);
        public static OrEval operator |(OrEval or, Evaluation eval)
        {
            or.Add(eval);
            return or;
        }

        public static NotEval operator !(Evaluation eval) => new NotEval(eval);
    }

    public partial class OrEval
    {
        // AND / OR
        public static AndEval operator &(OrEval eval1, OrEval eval2) => new AndEval(eval1, eval2);
        public static OrEval operator |(OrEval eval1, OrEval eval2) => new OrEval(eval1, eval2);
        public static OrEval operator |(OrEval eval1, AndEval eval2) => new OrEval(eval1, eval2);
        public static OrEval operator |(AndEval eval1, OrEval eval2) => new OrEval(eval1, eval2);

        // WHEN / THEN
        public static WhenThen operator |(OrEval eval, IExpression exp) => new WhenThen(eval, exp);
        public static WhenThen operator |(OrEval eval, int val) => new WhenThen(eval, new Expression(val));
        public static WhenThen operator |(OrEval eval, double val) => new WhenThen(eval, new Expression(val));
        public static WhenThen operator |(OrEval eval, string val) => new WhenThen(eval, new QuotedExpression(val));
    }

    public partial class AndEval
    {
        // AND / OR
        public static AndEval operator &(OrEval eval1, AndEval eval2) => new AndEval(eval1, eval2);
        public static AndEval operator &(AndEval eval1, OrEval eval2) => new AndEval(eval1, eval2);
        public static AndEval operator &(AndEval eval1, AndEval eval2) => new AndEval(eval1, eval2);
        public static OrEval operator |(AndEval eval1, AndEval eval2) => new OrEval(eval1, eval2);

        // WHEN / THEN
        public static WhenThen operator |(AndEval eval, IExpression exp) => new WhenThen(eval, exp);
        public static WhenThen operator |(AndEval eval, int val) => new WhenThen(eval, new Expression(val));
        public static WhenThen operator |(AndEval eval, double val) => new WhenThen(eval, new Expression(val));
        public static WhenThen operator |(AndEval eval, string val) => new WhenThen(eval, new QuotedExpression(val));
    }

    #endregion

    #region Expression

    public abstract partial class ExpressionBase<T>
    {
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();

        // Expression | Expression
        public static ExpressionEval operator ==(ExpressionBase<T> exp1, ExpressionBase<T> exp2) => new ExpressionEval(exp1, EvalType.Equal, exp2);
        public static ExpressionEval operator !=(ExpressionBase<T> exp1, ExpressionBase<T> exp2) => new ExpressionEval(exp1, EvalType.NotEqual, exp2);
        public static ExpressionEval operator >=(ExpressionBase<T> exp1, ExpressionBase<T> exp2) => new ExpressionEval(exp1, EvalType.GreaterThanOrEqualTo, exp2);
        public static ExpressionEval operator >(ExpressionBase<T> exp1, ExpressionBase<T> exp2) => new ExpressionEval(exp1, EvalType.GreaterThan, exp2);
        public static ExpressionEval operator <=(ExpressionBase<T> exp1, ExpressionBase<T> exp2) => new ExpressionEval(exp1, EvalType.LessThanOrEqualTo, exp2);
        public static ExpressionEval operator <(ExpressionBase<T> exp1, ExpressionBase<T> exp2) => new ExpressionEval(exp1, EvalType.LessThan, exp2);

        // Expression | int
        public static ExpressionEval operator ==(ExpressionBase<T> exp, int val) => new ExpressionEval(exp, EvalType.Equal, new Expression(val));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, int val) => new ExpressionEval(exp, EvalType.NotEqual, new Expression(val));
        public static ExpressionEval operator >=(ExpressionBase<T> exp, int val) => new ExpressionEval(exp, EvalType.GreaterThanOrEqualTo, new Expression(val));
        public static ExpressionEval operator >(ExpressionBase<T> exp, int val) => new ExpressionEval(exp, EvalType.GreaterThan, new Expression(val));
        public static ExpressionEval operator <=(ExpressionBase<T> exp, int val) => new ExpressionEval(exp, EvalType.LessThanOrEqualTo, new Expression(val));
        public static ExpressionEval operator <(ExpressionBase<T> exp, int val) => new ExpressionEval(exp, EvalType.LessThan, new Expression(val));

        // Int | Expression
        public static ExpressionEval operator ==(int val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.Equal, exp);
        public static ExpressionEval operator !=(int val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.NotEqual, exp);
        public static ExpressionEval operator >=(int val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.GreaterThanOrEqualTo, exp);
        public static ExpressionEval operator >(int val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.GreaterThan, exp);
        public static ExpressionEval operator <=(int val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.LessThanOrEqualTo, exp);
        public static ExpressionEval operator <(int val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.LessThan, exp);

        // Expression | double
        public static ExpressionEval operator ==(ExpressionBase<T> exp, double val) => new ExpressionEval(exp, EvalType.Equal, new Expression(val));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, double val) => new ExpressionEval(exp, EvalType.NotEqual, new Expression(val));
        public static ExpressionEval operator >=(ExpressionBase<T> exp, double val) => new ExpressionEval(exp, EvalType.GreaterThanOrEqualTo, new Expression(val));
        public static ExpressionEval operator >(ExpressionBase<T> exp, double val) => new ExpressionEval(exp, EvalType.GreaterThan, new Expression(val));
        public static ExpressionEval operator <=(ExpressionBase<T> exp, double val) => new ExpressionEval(exp, EvalType.LessThanOrEqualTo, new Expression(val));
        public static ExpressionEval operator <(ExpressionBase<T> exp, double val) => new ExpressionEval(exp, EvalType.LessThan, new Expression(val));

        // Double | Expression
        public static ExpressionEval operator ==(double val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.Equal, exp);
        public static ExpressionEval operator !=(double val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.NotEqual, exp);
        public static ExpressionEval operator >=(double val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.GreaterThanOrEqualTo, exp);
        public static ExpressionEval operator >(double val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.GreaterThan, exp);
        public static ExpressionEval operator <=(double val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.LessThanOrEqualTo, exp);
        public static ExpressionEval operator <(double val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.LessThan, exp);

        // Expression | decimal
        public static ExpressionEval operator ==(ExpressionBase<T> exp, decimal val) => new ExpressionEval(exp, EvalType.Equal, new Expression(val));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, decimal val) => new ExpressionEval(exp, EvalType.NotEqual, new Expression(val));
        public static ExpressionEval operator >=(ExpressionBase<T> exp, decimal val) => new ExpressionEval(exp, EvalType.GreaterThanOrEqualTo, new Expression(val));
        public static ExpressionEval operator >(ExpressionBase<T> exp, decimal val) => new ExpressionEval(exp, EvalType.GreaterThan, new Expression(val));
        public static ExpressionEval operator <=(ExpressionBase<T> exp, decimal val) => new ExpressionEval(exp, EvalType.LessThanOrEqualTo, new Expression(val));
        public static ExpressionEval operator <(ExpressionBase<T> exp, decimal val) => new ExpressionEval(exp, EvalType.LessThan, new Expression(val));

        // Decimal | Expression
        public static ExpressionEval operator ==(decimal val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.Equal, exp);
        public static ExpressionEval operator !=(decimal val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.NotEqual, exp);
        public static ExpressionEval operator >=(decimal val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.GreaterThanOrEqualTo, exp);
        public static ExpressionEval operator >(decimal val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.GreaterThan, exp);
        public static ExpressionEval operator <=(decimal val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.LessThanOrEqualTo, exp);
        public static ExpressionEval operator <(decimal val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val), EvalType.LessThan, exp);

        // Expression | String
        public static ExpressionEval operator ==(ExpressionBase<T> exp, string val) => new ExpressionEval(exp, EvalType.Equal, new QuotedExpression(val));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, string val) => new ExpressionEval(exp, EvalType.NotEqual, new QuotedExpression(val));
        public static ExpressionEval operator >=(ExpressionBase<T> exp, string val) => new ExpressionEval(exp, EvalType.GreaterThanOrEqualTo, new QuotedExpression(val));
        public static ExpressionEval operator >(ExpressionBase<T> exp, string val) => new ExpressionEval(exp, EvalType.GreaterThan, new QuotedExpression(val));
        public static ExpressionEval operator <=(ExpressionBase<T> exp, string val) => new ExpressionEval(exp, EvalType.LessThanOrEqualTo, new QuotedExpression(val));
        public static ExpressionEval operator <(ExpressionBase<T> exp, string val) => new ExpressionEval(exp, EvalType.LessThan, new QuotedExpression(val));

        // String | Expression
        public static ExpressionEval operator ==(string val, ExpressionBase<T> exp) => new ExpressionEval(new QuotedExpression(val), EvalType.Equal, exp);
        public static ExpressionEval operator !=(string val, ExpressionBase<T> exp) => new ExpressionEval(new QuotedExpression(val), EvalType.NotEqual, exp);
        public static ExpressionEval operator >=(string val, ExpressionBase<T> exp) => new ExpressionEval(new QuotedExpression(val), EvalType.GreaterThanOrEqualTo, exp);
        public static ExpressionEval operator >(string val, ExpressionBase<T> exp) => new ExpressionEval(new QuotedExpression(val), EvalType.GreaterThan, exp);
        public static ExpressionEval operator <=(string val, ExpressionBase<T> exp) => new ExpressionEval(new QuotedExpression(val), EvalType.LessThanOrEqualTo, exp);
        public static ExpressionEval operator <(string val, ExpressionBase<T> exp) => new ExpressionEval(new QuotedExpression(val), EvalType.LessThan, exp);

        // Expression | Boolean
        public static ExpressionEval operator ==(ExpressionBase<T> exp, bool val) => new ExpressionEval(exp, EvalType.Equal, new Expression(val ? 1 : 0));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, bool val) => new ExpressionEval(exp, EvalType.NotEqual, new Expression(val ? 1 : 0));

        // Boolean | Expression
        public static ExpressionEval operator ==(bool val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val ? 1 : 0), EvalType.Equal, exp);
        public static ExpressionEval operator !=(bool val, ExpressionBase<T> exp) => new ExpressionEval(new Expression(val ? 1 : 0), EvalType.NotEqual, exp);

        // Expression | IEnumerable<String>
        public static ExpressionEval operator ==(ExpressionBase<T> exp, IEnumerable<string> vals) => new ExpressionEval(exp, EvalType.In, new QuotedExpressions(vals));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, IEnumerable<string> vals) => new ExpressionEval(exp, EvalType.NotIn, new QuotedExpressions(vals));

        // IEnumerable<String> | Expression
        public static ExpressionEval operator ==(IEnumerable<string> vals, ExpressionBase<T> exp) => new ExpressionEval(new QuotedExpressions(vals), EvalType.In, exp);
        public static ExpressionEval operator !=(IEnumerable<string> vals, ExpressionBase<T> exp) => new ExpressionEval(new QuotedExpressions(vals), EvalType.NotIn, exp);

        // Expression | IEnumerable<int>
        public static ExpressionEval operator ==(ExpressionBase<T> exp, IEnumerable<int> vals) => new ExpressionEval(exp, EvalType.In, new Expressions(vals));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, IEnumerable<int> vals) => new ExpressionEval(exp, EvalType.NotIn, new Expressions(vals));

        // IEnumerable<int> | Expression
        public static ExpressionEval operator ==(IEnumerable<int> vals, ExpressionBase<T> exp) => new ExpressionEval(new Expressions(vals), EvalType.In, exp);
        public static ExpressionEval operator !=(IEnumerable<int> vals, ExpressionBase<T> exp) => new ExpressionEval(new Expressions(vals), EvalType.NotIn, exp);

        // Expression | IEnumerable<double>
        public static ExpressionEval operator ==(ExpressionBase<T> exp, IEnumerable<double> vals) => new ExpressionEval(exp, EvalType.In, new Expressions(vals));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, IEnumerable<double> vals) => new ExpressionEval(exp, EvalType.NotIn, new Expressions(vals));

        // IEnumerable<double> | Expression
        public static ExpressionEval operator ==(IEnumerable<double> vals, ExpressionBase<T> exp) => new ExpressionEval(new Expressions(vals), EvalType.In, exp);
        public static ExpressionEval operator !=(IEnumerable<double> vals, ExpressionBase<T> exp) => new ExpressionEval(new Expressions(vals), EvalType.NotIn, exp);

        // Expression | IEnumerable<decimal>
        public static ExpressionEval operator ==(ExpressionBase<T> exp, IEnumerable<decimal> vals) => new ExpressionEval(exp, EvalType.In, new Expressions(vals));
        public static ExpressionEval operator !=(ExpressionBase<T> exp, IEnumerable<decimal> vals) => new ExpressionEval(exp, EvalType.NotIn, new Expressions(vals));

        // IEnumerable<decimal> | Expression
        public static ExpressionEval operator ==(IEnumerable<decimal> vals, ExpressionBase<T> exp) => new ExpressionEval(new Expressions(vals), EvalType.In, exp);
        public static ExpressionEval operator !=(IEnumerable<decimal> vals, ExpressionBase<T> exp) => new ExpressionEval(new Expressions(vals), EvalType.NotIn, exp);
    }

    public partial class ExpressionEval
    {
        // Expression/Number | Expression/Number | Column
        public static ExpressionRangeEval operator &(ExpressionEval eval, IColumn column) => new ExpressionRangeEval(eval.Expression, eval.Value, column, eval.Type == EvalType.Equal);

        // Expression/Number | Expression/Number | Expression/Number
        public static ExpressionRangeEval operator &(ExpressionEval eval, IExpression exp) => new ExpressionRangeEval(eval.Expression, eval.Value, exp, eval.Type == EvalType.Equal);
        public static ExpressionRangeEval operator &(ExpressionEval eval, int val) => new ExpressionRangeEval(eval.Expression, eval.Value, val, eval.Type == EvalType.Equal);
        public static ExpressionRangeEval operator &(ExpressionEval eval, double val) => new ExpressionRangeEval(eval.Expression, eval.Value, val, eval.Type == EvalType.Equal);
        public static ExpressionRangeEval operator &(ExpressionEval eval, decimal val) => new ExpressionRangeEval(eval.Expression, eval.Value, val, eval.Type == EvalType.Equal);
        public static ExpressionRangeEval operator &(ExpressionEval eval, string val) => new ExpressionRangeEval(eval.Expression, eval.Value, new QuotedExpression(val), eval.Type == EvalType.Equal);
    }

    #endregion

    #region Set

    public partial class RawSet
    {
        public static implicit operator string(RawSet rawSet) => rawSet.nameOrSubstring;

        public static implicit operator RawSet(string rawSet) => new RawSet(rawSet);
    }

    #endregion
}
