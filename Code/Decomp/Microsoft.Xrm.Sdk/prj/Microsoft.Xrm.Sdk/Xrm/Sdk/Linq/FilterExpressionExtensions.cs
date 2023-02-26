// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.FilterExpressionExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System.Collections.ObjectModel;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class FilterExpressionExtensions
  {
    public static void ForSubtreePreorder(
      this FilterExpression exp,
      FilterExpressionExtensions.FilterAction action)
    {
      exp.ForSubtreePreorder((FilterExpression) null, action);
    }

    public static void ForSubtreePreorder(
      this FilterExpression exp,
      FilterExpression parent,
      FilterExpressionExtensions.FilterAction action)
    {
      action(exp, parent);
      if (exp.Filters == null)
        return;
      foreach (FilterExpression filter in (Collection<FilterExpression>) exp.Filters)
        filter.ForSubtreePreorder(exp, action);
    }

    public static void ForSubtreePreorder(
      this FilterExpression exp,
      FilterExpressionExtensions.FilterAction filterAction,
      FilterExpressionExtensions.ConditionAction conditionAction)
    {
      exp.ForSubtreePreorder((FilterExpression) null, filterAction, conditionAction);
    }

    public static void ForSubtreePreorder(
      this FilterExpression exp,
      FilterExpression parent,
      FilterExpressionExtensions.FilterAction filterAction,
      FilterExpressionExtensions.ConditionAction conditionAction)
    {
      exp.ForSubtreePreorder(parent, (FilterExpressionExtensions.FilterAction) ((e, p) =>
      {
        filterAction(e, p);
        if (e.Conditions == null)
          return;
        foreach (ConditionExpression condition in (Collection<ConditionExpression>) e.Conditions)
          conditionAction(condition, e);
      }));
    }

    public static void ForSubtreePostorder(
      this FilterExpression exp,
      FilterExpressionExtensions.FilterAction action)
    {
      exp.ForSubtreePostorder((FilterExpression) null, action);
    }

    public static void ForSubtreePostorder(
      this FilterExpression exp,
      FilterExpression parent,
      FilterExpressionExtensions.FilterAction action)
    {
      if (exp.Filters != null)
      {
        foreach (FilterExpression filter in (Collection<FilterExpression>) exp.Filters)
          filter.ForSubtreePostorder(exp, action);
      }
      action(exp, parent);
    }

    public static void ForSubtreePostorder(
      this FilterExpression exp,
      FilterExpressionExtensions.FilterAction filterAction,
      FilterExpressionExtensions.ConditionAction conditionAction)
    {
      exp.ForSubtreePostorder((FilterExpression) null, filterAction, conditionAction);
    }

    public static void ForSubtreePostorder(
      this FilterExpression exp,
      FilterExpression parent,
      FilterExpressionExtensions.FilterAction filterAction,
      FilterExpressionExtensions.ConditionAction conditionAction)
    {
      exp.ForSubtreePostorder(parent, (FilterExpressionExtensions.FilterAction) ((e, p) =>
      {
        if (e.Conditions != null)
        {
          foreach (ConditionExpression condition in (Collection<ConditionExpression>) e.Conditions)
            conditionAction(condition, e);
        }
        filterAction(e, p);
      }));
    }

    public delegate void FilterAction(FilterExpression exp, FilterExpression parent);

    public delegate void ConditionAction(ConditionExpression exp, FilterExpression parent);
  }
}
