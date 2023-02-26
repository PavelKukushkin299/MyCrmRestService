// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.QueryProvider
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal class QueryProvider : IQueryProvider
  {
    private readonly OrganizationServiceContext _context;
    private static readonly IEnumerable<string> _followingRoot = (IEnumerable<string>) new string[1];
    private static readonly IEnumerable<string> _followingFirst = QueryProvider._followingRoot.Concat<string>((IEnumerable<string>) new string[1]
    {
      "ToList"
    });
    private static readonly IEnumerable<string> _followingTake = QueryProvider._followingFirst.Concat<string>((IEnumerable<string>) new string[6]
    {
      "Select",
      "First",
      "FirstOrDefault",
      "Single",
      "SingleOrDefault",
      "Distinct"
    });
    private static readonly IEnumerable<string> _followingSkip = QueryProvider._followingTake.Concat<string>((IEnumerable<string>) new string[1]
    {
      "Take"
    });
    private static readonly IEnumerable<string> _followingSelect = QueryProvider._followingSkip.Concat<string>((IEnumerable<string>) new string[1]
    {
      "Skip"
    });
    private static readonly IEnumerable<string> _followingOrderBy = QueryProvider._followingSelect.Concat<string>((IEnumerable<string>) new string[6]
    {
      "Select",
      "Where",
      "OrderBy",
      "OrderByDescending",
      "ThenBy",
      "ThenByDescending"
    });
    private static readonly IEnumerable<string> _followingWhere = QueryProvider._followingOrderBy.Concat<string>((IEnumerable<string>) new string[1]
    {
      "SelectMany"
    });
    private static readonly IEnumerable<string> _followingJoin = QueryProvider._followingWhere.Concat<string>((IEnumerable<string>) new string[1]
    {
      "Join"
    });
    private static readonly IEnumerable<string> _followingGroupJoin = QueryProvider._followingRoot.Concat<string>((IEnumerable<string>) new string[1]
    {
      "SelectMany"
    });
    private static readonly Dictionary<string, IEnumerable<string>> _followingMethodLookup = new Dictionary<string, IEnumerable<string>>()
    {
      {
        "Join",
        QueryProvider._followingJoin
      },
      {
        "GroupJoin",
        QueryProvider._followingGroupJoin
      },
      {
        "Where",
        QueryProvider._followingWhere
      },
      {
        "OrderBy",
        QueryProvider._followingOrderBy
      },
      {
        "OrderByDescending",
        QueryProvider._followingOrderBy
      },
      {
        "ThenBy",
        QueryProvider._followingOrderBy
      },
      {
        "ThenByDescending",
        QueryProvider._followingOrderBy
      },
      {
        "Select",
        QueryProvider._followingSelect
      },
      {
        "Skip",
        QueryProvider._followingSkip
      },
      {
        "Take",
        QueryProvider._followingTake
      },
      {
        "First",
        QueryProvider._followingFirst
      },
      {
        "FirstOrDefault",
        QueryProvider._followingFirst
      },
      {
        "Single",
        QueryProvider._followingFirst
      },
      {
        "SingleOrDefault",
        QueryProvider._followingFirst
      },
      {
        "SelectMany",
        QueryProvider._followingOrderBy
      },
      {
        "Distinct",
        QueryProvider._followingSkip
      },
      {
        "Cast",
        (IEnumerable<string>) new string[1]
        {
          "Select"
        }
      }
    };
    private static readonly string[] _supportedMethods = new string[4]
    {
      "Equals",
      "Contains",
      "StartsWith",
      "EndsWith"
    };
    private static readonly string[] _validMethods = ((IEnumerable<string>) QueryProvider._supportedMethods).Concat<string>((IEnumerable<string>) new string[3]
    {
      "Compare",
      "Like",
      "GetValueOrDefault"
    }).ToArray<string>();
    private static readonly string[] _validProperties = new string[2]
    {
      "Id",
      "Value"
    };
    private static readonly Dictionary<ExpressionType, ConditionOperator> _conditionLookup = new Dictionary<ExpressionType, ConditionOperator>()
    {
      {
        ExpressionType.Equal,
        ConditionOperator.Equal
      },
      {
        ExpressionType.GreaterThan,
        ConditionOperator.GreaterThan
      },
      {
        ExpressionType.GreaterThanOrEqual,
        ConditionOperator.GreaterEqual
      },
      {
        ExpressionType.LessThan,
        ConditionOperator.LessThan
      },
      {
        ExpressionType.LessThanOrEqual,
        ConditionOperator.LessEqual
      },
      {
        ExpressionType.NotEqual,
        ConditionOperator.NotEqual
      }
    };
    private static readonly Dictionary<ConditionOperator, ConditionOperator> _operatorNegationLookup = new Dictionary<ConditionOperator, ConditionOperator>()
    {
      {
        ConditionOperator.Equal,
        ConditionOperator.NotEqual
      },
      {
        ConditionOperator.NotEqual,
        ConditionOperator.Equal
      },
      {
        ConditionOperator.GreaterThan,
        ConditionOperator.LessEqual
      },
      {
        ConditionOperator.GreaterEqual,
        ConditionOperator.LessThan
      },
      {
        ConditionOperator.LessThan,
        ConditionOperator.GreaterEqual
      },
      {
        ConditionOperator.LessEqual,
        ConditionOperator.GreaterThan
      },
      {
        ConditionOperator.Like,
        ConditionOperator.NotLike
      },
      {
        ConditionOperator.NotLike,
        ConditionOperator.Like
      },
      {
        ConditionOperator.Null,
        ConditionOperator.NotNull
      },
      {
        ConditionOperator.NotNull,
        ConditionOperator.Null
      }
    };
    private static readonly Dictionary<ExpressionType, LogicalOperator> _booleanLookup = new Dictionary<ExpressionType, LogicalOperator>()
    {
      {
        ExpressionType.And,
        LogicalOperator.And
      },
      {
        ExpressionType.Or,
        LogicalOperator.Or
      },
      {
        ExpressionType.AndAlso,
        LogicalOperator.And
      },
      {
        ExpressionType.OrElse,
        LogicalOperator.Or
      }
    };
    private static readonly Dictionary<LogicalOperator, LogicalOperator> _logicalOperatorNegationLookup = new Dictionary<LogicalOperator, LogicalOperator>()
    {
      {
        LogicalOperator.And,
        LogicalOperator.Or
      },
      {
        LogicalOperator.Or,
        LogicalOperator.And
      }
    };

    public QueryProvider(OrganizationServiceContext context) => this._context = context;

    protected OrganizationServiceContext OrganizationServiceContext => this._context;

    private IQueryable CreateQuery(Type entityType)
    {
      this.CheckEntitySubclass(entityType);
      string nameForType = KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType);
      return this.CreateQueryInstance(entityType, new object[2]
      {
        (object) this,
        (object) nameForType
      });
    }

    private IQueryable<TElement> CreateQuery<TElement>(Expression expression) => (IQueryable<TElement>) new Microsoft.Xrm.Sdk.Linq.Query<TElement>((IQueryProvider) this, expression);

    private IQueryable CreateQuery(Expression expression) => this.CreateQueryInstance(expression.Type.GetGenericArguments()[0], new object[2]
    {
      (object) this,
      (object) expression
    });

    IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(
      Expression expression)
    {
      ClientExceptionHelper.ThrowIfNull((object) expression, nameof (expression));
      return this.CreateQuery<TElement>(expression);
    }

    IQueryable IQueryProvider.CreateQuery(Expression expression)
    {
      ClientExceptionHelper.ThrowIfNull((object) expression, nameof (expression));
      return this.CreateQuery(expression);
    }

    TResult IQueryProvider.Execute<TResult>(Expression expression)
    {
      ClientExceptionHelper.ThrowIfNull((object) expression, nameof (expression));
      return this.Execute<TResult>(expression).FirstOrDefault<TResult>();
    }

    object IQueryProvider.Execute(Expression expression)
    {
      ClientExceptionHelper.ThrowIfNull((object) expression, nameof (expression));
      return this.Execute<object>(expression).FirstOrDefault<object>();
    }

    public virtual IEnumerator<TElement> GetEnumerator<TElement>(Expression expression) => this.Execute<TElement>(expression).GetEnumerator();

    private IQueryable CreateQueryInstance(Type elementType, object[] args)
    {
      try
      {
        return Activator.CreateInstance(typeof (Microsoft.Xrm.Sdk.Linq.Query<>).MakeGenericType(elementType), args) as IQueryable;
      }
      catch (TargetInvocationException ex)
      {
        this.ThrowException(ex.InnerException);
        throw;
      }
    }

    private void CheckEntitySubclass(Type entityType)
    {
      if (!entityType.IsSubclassOf(typeof (Entity)))
        this.ThrowException((Exception) new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The specified type '{0}' must be a subclass of '{1}'.", (object) entityType, (object) typeof (Entity))));
      if (!string.IsNullOrWhiteSpace(KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType)))
        return;
      this.ThrowException((Exception) new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The specified type '{0}' is not a known entity type.", (object) entityType)));
    }

    public IEnumerable<TElement> Execute<TElement>(Expression expression)
    {
      QueryProvider.NavigationSource source = (QueryProvider.NavigationSource) null;
      List<QueryProvider.LinkLookup> linkLookups = new List<QueryProvider.LinkLookup>();
      bool throwIfSequenceIsEmpty;
      bool throwIfSequenceNotSingle;
      QueryProvider.Projection projection;
      return this.Execute<TElement>(this.GetQueryExpression(expression, out throwIfSequenceIsEmpty, out throwIfSequenceNotSingle, out projection, ref source, ref linkLookups), throwIfSequenceIsEmpty, throwIfSequenceNotSingle, projection, source, linkLookups);
    }

    protected IEnumerable<TElement> Execute<TElement>(
      QueryExpression qe,
      bool throwIfSequenceIsEmpty,
      bool throwIfSequenceNotSingle,
      QueryProvider.Projection projection,
      QueryProvider.NavigationSource source,
      List<QueryProvider.LinkLookup> linkLookups)
    {
      string pagingCookie = (string) null;
      bool moreRecords = false;
      return (IEnumerable<TElement>) new PagedItemCollection<TElement>(this.Execute(qe, throwIfSequenceIsEmpty, throwIfSequenceNotSingle, projection, source, linkLookups, out pagingCookie, out moreRecords).Cast<TElement>(), qe, pagingCookie, moreRecords);
    }

    private IEnumerable Execute(
      QueryExpression qe,
      bool throwIfSequenceIsEmpty,
      bool throwIfSequenceNotSingle,
      QueryProvider.Projection projection,
      QueryProvider.NavigationSource source,
      List<QueryProvider.LinkLookup> linkLookups,
      out string pagingCookie,
      out bool moreRecords)
    {
      IEnumerable<Entity> entities = (IEnumerable<Entity>) null;
      pagingCookie = (string) null;
      moreRecords = false;
      OrganizationRequest request;
      if (source != null)
      {
        RelationshipQueryCollection relationshipQueryCollection1 = new RelationshipQueryCollection();
        relationshipQueryCollection1.Add(source.Relationship, (QueryBase) qe);
        RelationshipQueryCollection relationshipQueryCollection2 = relationshipQueryCollection1;
        request = (OrganizationRequest) new RetrieveRequest()
        {
          Target = source.Target,
          ColumnSet = new ColumnSet(),
          RelatedEntitiesQuery = relationshipQueryCollection2
        };
      }
      else
        request = (OrganizationRequest) new RetrieveMultipleRequest()
        {
          Query = (QueryBase) qe
        };
      int? nullable1 = new int?();
      if (qe.PageInfo != null)
        nullable1 = new int?(qe.PageInfo.Count);
      bool moreRecordAfterAdjust = true;
      EntityCollection entityCollection1 = (this.AdjustPagingInfo(request, qe, source, out moreRecordAfterAdjust) ? 1 : 0) == 0 ? this.AdjustEntityCollection(request, qe, source) : (moreRecordAfterAdjust ? this.RetrieveEntityCollection(request, source) : new EntityCollection());
      if (throwIfSequenceIsEmpty && (entityCollection1 == null || entityCollection1.Entities.Count == 0))
        this.ThrowException((Exception) new InvalidOperationException("Sequence contains no elements"));
      if (throwIfSequenceNotSingle && entityCollection1 != null && entityCollection1.Entities.Count > 1)
        this.ThrowException((Exception) new InvalidOperationException("Sequence contains more than one element"));
      if (entityCollection1 != null)
      {
        pagingCookie = entityCollection1.PagingCookie;
        moreRecords = entityCollection1.MoreRecords;
        int count = entityCollection1.Entities.Count;
        EntityCollection entityCollection2 = entityCollection1;
        while (moreRecords)
        {
          int? nullable2;
          if (nullable1.HasValue)
          {
            nullable2 = nullable1;
            int num = count;
            if (nullable2.GetValueOrDefault() > num & nullable2.HasValue)
            {
              qe.PageInfo.Count = nullable1.Value - count;
              goto label_16;
            }
          }
          if (nullable1.HasValue)
          {
            nullable2 = nullable1;
            int num = 0;
            if (nullable2.GetValueOrDefault() > num & nullable2.HasValue)
              break;
          }
label_16:
          if (string.IsNullOrEmpty(pagingCookie))
            this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Paging cookie required to retrieve more records. Update your query to retrieve with total records below {0}", (object) this.RetrievalUpperLimitWithoutPagingCookie)));
          qe.PageInfo.PagingCookie = entityCollection2.PagingCookie;
          ++qe.PageInfo.PageNumber;
          qe.PageInfo.Count = qe.PageInfo.Count < this.RetrievalUpperLimitWithoutPagingCookie ? qe.PageInfo.Count : this.RetrievalUpperLimitWithoutPagingCookie;
          entityCollection2 = this.RetrieveEntityCollection(request, source);
          if (entityCollection2 != null && entityCollection2.Entities.Count > 0)
          {
            pagingCookie = entityCollection2.PagingCookie;
            moreRecords = entityCollection2.MoreRecords;
            count += entityCollection2.Entities.Count;
            entityCollection1.Entities.AddRange((IEnumerable<Entity>) entityCollection2.Entities);
          }
          else
            break;
        }
        entities = (IEnumerable<Entity>) entityCollection1.Entities;
      }
      return projection != null ? this.ExecuteAnonymousType(entities, projection, linkLookups) : (IEnumerable) entities.Select<Entity, Entity>(new Func<Entity, Entity>(this.AttachToContext));
    }

    private EntityCollection RetrieveEntityCollection(
      OrganizationRequest request,
      QueryProvider.NavigationSource source)
    {
      if (request == null || string.IsNullOrEmpty(request.RequestName) || !(request.RequestName == "Retrieve") && !(request.RequestName == "RetrieveMultiple"))
        this.ThrowException((Exception) new ArgumentException("Invalid request", nameof (request)));
      EntityCollection entityCollection;
      if (source != null)
      {
        RetrieveResponse retrieveResponse = this._context.Execute(request) as RetrieveResponse;
        entityCollection = retrieveResponse.Entity.RelatedEntities.Contains(source.Relationship) ? retrieveResponse.Entity.RelatedEntities[source.Relationship] : (EntityCollection) null;
      }
      else
        entityCollection = (this._context.Execute(request) as RetrieveMultipleResponse).EntityCollection;
      return entityCollection;
    }

    private static string ResetPagingNumber(string pagingCookie, int newPage)
    {
      if (string.IsNullOrEmpty(pagingCookie))
        return pagingCookie;
      int pageNumber = 0;
      return PagingCookieHelper.ToPagingCookie(PagingCookieHelper.ToContinuationToken(pagingCookie, newPage), out pageNumber, new StringBuilder());
    }

    private static void ResetPagingInfo(PagingInfo pagingInfo, string pagingCookie, int skipValue)
    {
      if (string.IsNullOrEmpty(pagingCookie))
      {
        pagingInfo.PageNumber = skipValue;
        pagingInfo.Count = 1;
      }
      else
      {
        pagingInfo.PagingCookie = QueryProvider.ResetPagingNumber(pagingCookie, 1);
        pagingInfo.PageNumber = skipValue + 1;
        pagingInfo.Count = 1;
      }
    }

    private static bool IsPagingCookieNull(EntityCollection entityCollection) => entityCollection != null && string.IsNullOrEmpty(entityCollection.PagingCookie);

    private bool AdjustPagingInfo(
      OrganizationRequest request,
      QueryExpression qe,
      QueryProvider.NavigationSource source,
      out bool moreRecordAfterAdjust)
    {
      moreRecordAfterAdjust = true;
      if (request == null || qe == null || qe.PageInfo == null || !string.IsNullOrEmpty(qe.PageInfo.PagingCookie))
        return true;
      PagingInfo pageInfo = qe.PageInfo;
      EntityCollection entityCollection = (EntityCollection) null;
      int pageNumber = pageInfo.PageNumber;
      int count = pageInfo.Count;
      int num1 = count > this.RetrievalUpperLimitWithoutPagingCookie ? this.RetrievalUpperLimitWithoutPagingCookie : count;
      if (pageNumber > 0)
      {
        int num2 = pageNumber / this.RetrievalUpperLimitWithoutPagingCookie;
        int skipValue = pageNumber % this.RetrievalUpperLimitWithoutPagingCookie;
        if (num2 > 0)
        {
          for (int index = 0; index < num2; ++index)
          {
            QueryProvider.ResetPagingInfo(pageInfo, entityCollection == null ? (string) null : entityCollection.PagingCookie, this.RetrievalUpperLimitWithoutPagingCookie);
            entityCollection = this.RetrieveEntityCollection(request, source);
            if (QueryProvider.IsPagingCookieNull(entityCollection))
            {
              pageInfo.PageNumber = pageNumber;
              pageInfo.Count = num1;
              return false;
            }
            if (entityCollection != null && !entityCollection.MoreRecords)
            {
              moreRecordAfterAdjust = false;
              return true;
            }
          }
        }
        if (skipValue > 0 && !QueryProvider.IsPagingCookieNull(entityCollection))
        {
          QueryProvider.ResetPagingInfo(pageInfo, entityCollection == null ? (string) null : entityCollection.PagingCookie, skipValue);
          entityCollection = this.RetrieveEntityCollection(request, source);
          if (QueryProvider.IsPagingCookieNull(entityCollection))
          {
            pageInfo.PageNumber = pageNumber;
            pageInfo.Count = num1;
            return false;
          }
          if (entityCollection != null && !entityCollection.MoreRecords)
          {
            moreRecordAfterAdjust = false;
            return true;
          }
        }
        pageInfo.PagingCookie = QueryProvider.ResetPagingNumber(entityCollection.PagingCookie, 1);
        pageInfo.PageNumber = 2;
        pageInfo.Count = num1;
      }
      if (pageInfo.PageNumber == 0)
        pageInfo.PageNumber = 1;
      return true;
    }

    private EntityCollection AdjustEntityCollection(
      OrganizationRequest request,
      QueryExpression qe,
      QueryProvider.NavigationSource source)
    {
      if (request == null || qe == null || qe.PageInfo == null || !string.IsNullOrEmpty(qe.PageInfo.PagingCookie))
        return new EntityCollection();
      PagingInfo pageInfo = qe.PageInfo;
      int pageNumber = pageInfo.PageNumber;
      int count = pageInfo.Count;
      if (pageNumber >= this.RetrievalUpperLimitWithoutPagingCookie)
        this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Skipping records beyond {0} is not supported", (object) this.RetrievalUpperLimitWithoutPagingCookie)));
      pageInfo.PageNumber = 1;
      if (count > 0)
        pageInfo.Count = pageNumber + count > this.RetrievalUpperLimitWithoutPagingCookie ? this.RetrievalUpperLimitWithoutPagingCookie : pageNumber + count;
      EntityCollection entityCollection1 = this.RetrieveEntityCollection(request, source);
      if (entityCollection1 != null && !string.IsNullOrEmpty(entityCollection1.PagingCookie))
        this.ThrowException((Exception) new InvalidOperationException("Queries with valid paging cookie should not be executed in this strategy"));
      if (pageNumber <= 0)
        return entityCollection1;
      EntityCollection entityCollection2 = pageNumber >= entityCollection1.Entities.Count ? new EntityCollection() : new EntityCollection((IList<Entity>) entityCollection1.Entities.Skip<Entity>(pageNumber).ToList<Entity>());
      entityCollection2.EntityName = entityCollection1.EntityName;
      entityCollection2.MoreRecords = entityCollection1.MoreRecords;
      return entityCollection2;
    }

    protected virtual int RetrievalUpperLimitWithoutPagingCookie => 5000;

    private IEnumerable ExecuteAnonymousType(
      IEnumerable<Entity> entities,
      QueryProvider.Projection projection,
      List<QueryProvider.LinkLookup> linkLookups)
    {
            //Delegate project = this.CompileExpression(projection.Expression);
            //return (IEnumerable) entities.Select(entity => new
            //{
            //  entity = entity,
            //  args = this.BuildProjection(projection, entity, (IList<QueryProvider.LinkLookup>) linkLookups)
            //}).Select(_param1 => new
            //{
            //  \u003C\u003Eh__TransparentIdentifier0 = _param1,
            //  element = this.DynamicInvoke(project, _param1.args)
            //}).Select(_param1 => new
            //{
            //  \u003C\u003Eh__TransparentIdentifier1 = _param1,
            //  result = _param1.element as Entity
            //}).Select(_param1 => _param1.result == null || !(_param1.result.Id != Guid.Empty) ? _param1.\u003C\u003Eh__TransparentIdentifier1.element : (object) this.AttachToContext(_param1.result));
            // тут
            throw new NotImplementedException();
        }

    [SecuritySafeCritical]
    private Delegate CompileExpression(LambdaExpression expression)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
        return expression.Compile();
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    [SecuritySafeCritical]
    private object DynamicInvoke(Delegate project, params object[] args)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
        return project.DynamicInvoke(args);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    [SecuritySafeCritical]
    private object ConstructorInvoke(ConstructorInfo ci, object[] parameters)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Assert();
        return ci.Invoke(parameters);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    private Entity AttachToContext(Entity entity) => this._context.MergeEntity(entity);

    private object[] BuildProjection(
      QueryProvider.Projection projection,
      Entity entity,
      IList<QueryProvider.LinkLookup> linkLookups)
    {
      if (entity == null)
        return (object[]) null;
      if (linkLookups.Count == 0)
        return (object[]) new Entity[1]
        {
          this.AttachToContext(entity)
        };
      ReadOnlyCollection<ParameterExpression> parameters = projection.Expression.Parameters;
      if (linkLookups.Count != 2 || parameters.Count != 2)
        return parameters.Select<ParameterExpression, object>((Func<ParameterExpression, object>) (parameter => this.BuildProjection((string) null, projection.MethodName, parameter.Type, entity, (IEnumerable<QueryProvider.LinkLookup>) linkLookups))).ToArray<object>();
      return new object[2]
      {
        linkLookups[1].Link.JoinOperator == JoinOperator.LeftOuter ? this.BuildProjection((string) null, projection.MethodName, parameters[0].Type, entity, (IEnumerable<QueryProvider.LinkLookup>) linkLookups) : (object) entity,
        this.BuildProjectionParameter(parameters[1].Type, entity, linkLookups[1])
      };
    }

    private object BuildProjection(
      string environment,
      string projectingMethodName,
      Type entityType,
      Entity entity,
      IEnumerable<QueryProvider.LinkLookup> linkLookups)
    {
      if (this.IsEntity(entityType))
        return this.BuildProjectionParameter((string) null, projectingMethodName, entityType, entity, linkLookups) ?? (object) entity;
      ConstructorInfo[] constructors = entityType.GetConstructors();
      if (QueryProvider.IsAnonymousType(entityType) && constructors.Length != 1)
        this.ThrowException((Exception) new InvalidOperationException("The result selector of the 'Join' operation is not returning a valid anonymous type."));
      ConstructorInfo ci = ((IEnumerable<ConstructorInfo>) constructors).First<ConstructorInfo>();
      ParameterInfo[] parameters = ci.GetParameters();
      if (parameters.Length != 2)
        this.ThrowException((Exception) new InvalidOperationException("The result selector of the 'Join' operation must return an anonymous type of two properties."));
      ParameterInfo parameterInfo1 = parameters[0];
      ParameterInfo parameterInfo2 = parameters[1];
      if (this.IsEntity(parameterInfo1.ParameterType) && this.IsEntity(parameterInfo2.ParameterType))
      {
        object obj1 = this.BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, parameterInfo1.ParameterType, entity, linkLookups);
        object obj2 = this.BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, parameterInfo2.ParameterType, entity, linkLookups);
        return this.ConstructorInvoke(ci, new object[2]
        {
          obj1,
          obj2
        });
      }
      if (this.IsEntity(parameterInfo2.ParameterType))
      {
        object obj3 = this.BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, entity, linkLookups);
        object obj4 = this.BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, parameterInfo2.ParameterType, entity, linkLookups);
        return this.ConstructorInvoke(ci, new object[2]
        {
          obj3,
          obj4
        });
      }
      if (this.IsEntity(parameterInfo1.ParameterType))
      {
        object obj5 = this.BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, parameterInfo1.ParameterType, entity, linkLookups);
        object obj6 = this.BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, entity, linkLookups);
        return this.ConstructorInvoke(ci, new object[2]
        {
          obj5,
          obj6
        });
      }
      this.ThrowException((Exception) new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Invalid left '{0}' and right '{1}' parameters.", (object) parameterInfo1.ParameterType.Name, (object) parameterInfo2.ParameterType.Name)));
      return (object) null;
    }

    private object BuildProjectionParameter(
      ParameterInfo parameter,
      string environment,
      string projectingMethodName,
      Entity entity,
      IEnumerable<QueryProvider.LinkLookup> linkLookups)
    {
      return parameter.ParameterType.IsGenericType && parameter.ParameterType.GetGenericTypeDefinition() == typeof (IEnumerable<>) ? (object) null : this.BuildProjection(QueryProvider.GetEnvironment(parameter, environment), projectingMethodName, parameter.ParameterType, entity, linkLookups);
    }

    private object BuildProjectionParameter(
      ParameterInfo pi,
      string environment,
      string projectingMethodName,
      Type entityType,
      Entity entity,
      IEnumerable<QueryProvider.LinkLookup> linkLookups)
    {
      return this.BuildProjectionParameter(QueryProvider.GetEnvironment(pi, environment), projectingMethodName, entityType, entity, linkLookups);
    }

    private object BuildProjectionParameter(
      string environment,
      string projectingMethodName,
      Type entityType,
      Entity entity,
      IEnumerable<QueryProvider.LinkLookup> linkLookups)
    {
      QueryProvider.LinkLookup link = projectingMethodName == "SelectMany" ? linkLookups.SingleOrDefault<QueryProvider.LinkLookup>((Func<QueryProvider.LinkLookup, bool>) (l => l.SelectManyEnvironment != null && l.SelectManyEnvironment == environment)) : linkLookups.SingleOrDefault<QueryProvider.LinkLookup>((Func<QueryProvider.LinkLookup, bool>) (l => l.Environment == environment));
      if (link != null)
        return this.BuildProjectionParameter(entityType, entity, link);
      this.ThrowException((Exception) new InvalidOperationException("The projection property does not match an existing entity binding."));
      return (object) null;
    }

    private object BuildProjectionParameter(
      Type entityType,
      Entity entity,
      QueryProvider.LinkLookup link)
    {
      if (link.Link == null)
        return (object) entity;
      Entity entity1 = entityType == typeof (Entity) ? new Entity(link.Link.LinkToEntityName) : Activator.CreateInstance(entityType) as Entity;
      string entityAlias = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}.", (object) link.Link.EntityAlias);
      int aliasIndex = entityAlias.Length;
      foreach (var data in entity.Attributes.Where<KeyValuePair<string, object>>((Func<KeyValuePair<string, object>, bool>) (a => a.Value is AliasedValue && a.Key.StartsWith(entityAlias, StringComparison.Ordinal))).Select(a => new
      {
        Key = a.Key.Substring(aliasIndex),
        Value = (a.Value as AliasedValue).Value
      }))
        entity1.Attributes.Add(data.Key, data.Value);
      return (object) entity1;
    }

    private static string GetEnvironment(ParameterInfo pi, string environment) => environment == null ? pi.Name : string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}.{1}", (object) environment, (object) pi.Name);

    public QueryExpression Translate(Expression expression)
    {
      QueryProvider.NavigationSource source = (QueryProvider.NavigationSource) null;
      List<QueryProvider.LinkLookup> linkLookups = (List<QueryProvider.LinkLookup>) null;
      return this.GetQueryExpression(expression, out bool _, out bool _, out QueryProvider.Projection _, ref source, ref linkLookups);
    }

    protected virtual bool IsValidFollowingMethod(string method, string next)
    {
      IEnumerable<string> source;
      return QueryProvider._followingMethodLookup.TryGetValue(method, out source) && source.Contains<string>(next);
    }

    private bool IsValidMethod(string method) => QueryProvider._followingMethodLookup.ContainsKey(method);

    private QueryExpression GetQueryExpression(
      Expression expression,
      out bool throwIfSequenceIsEmpty,
      out bool throwIfSequenceNotSingle,
      out QueryProvider.Projection projection,
      ref QueryProvider.NavigationSource source,
      ref List<QueryProvider.LinkLookup> linkLookups)
    {
      throwIfSequenceIsEmpty = false;
      throwIfSequenceNotSingle = false;
      projection = (QueryProvider.Projection) null;
      int? skipVal = new int?();
      int? takeVal = new int?();
      QueryExpression qe = new QueryExpression();
      List<MethodCallExpression> list = expression.GetMethodsPostorder().ToList<MethodCallExpression>();
      bool flag = list.Count > 0 && (list[0].Method.Name == "Join" || list[0].Method.Name == "GroupJoin");
      for (int i = 0; i < list.Count; ++i)
      {
        MethodCallExpression mce = list[i];
        string name1 = mce.Method.Name;
        if (!this.IsValidMethod(name1))
          this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The method '{0}' is not supported.", (object) name1)));
        if (i > 0)
        {
          string name2 = list[i - 1].Method.Name;
          if (!this.IsValidFollowingMethod(name2, name1))
            this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The method '{0}' cannot follow the method '{1}' or is not supported. Try writing the query in terms of supported methods or call the 'AsEnumerable' or 'ToList' method before calling unsupported methods.", (object) name1, (object) name2)));
        }
        int? nullable;
        switch (name1)
        {
          case "Distinct":
            qe.Distinct = true;
            break;
          case "First":
          case "FirstOrDefault":
          case "Single":
          case "SingleOrDefault":
          case "Where":
            if (name1 != "Where")
              takeVal = new int?(1);
            if (name1 == "First" || name1 == "Single")
              throwIfSequenceIsEmpty = true;
            if (name1 == "SingleOrDefault" || name1 == "Single")
            {
              takeVal = new int?(2);
              throwIfSequenceNotSingle = true;
            }
            string parameterName1;
            Expression methodCallBody1 = this.GetMethodCallBody(mce, out parameterName1);
            if (methodCallBody1 != null)
            {
              this.TranslateWhere(qe, parameterName1, methodCallBody1, linkLookups);
              break;
            }
            break;
          case "GroupJoin":
            this.TranslateGroupJoin(qe, (IList<MethodCallExpression>) list, ref i, out projection, out linkLookups);
            break;
          case "Join":
            this.TranslateJoin(qe, (IList<MethodCallExpression>) list, ref i, out projection, out linkLookups);
            break;
          case "OrderBy":
          case "ThenBy":
            string parameterName2;
            Expression methodCallBody2 = this.GetMethodCallBody(mce, out parameterName2);
            this.TranslateOrderBy(qe, methodCallBody2, OrderType.Ascending, parameterName2, linkLookups);
            break;
          case "OrderByDescending":
          case "ThenByDescending":
            string parameterName3;
            Expression methodCallBody3 = this.GetMethodCallBody(mce, out parameterName3);
            this.TranslateOrderBy(qe, methodCallBody3, OrderType.Descending, parameterName3, linkLookups);
            break;
          case "Select":
            if (linkLookups != null && !flag)
              linkLookups.Clear();
            this.TranslateEntityName(qe, expression, mce);
            LambdaExpression operand1 = (mce.Arguments[1] as UnaryExpression).Operand as LambdaExpression;
            projection = new QueryProvider.Projection(name1, operand1);
            Expression expression1 = this.TranslateSelect((IList<MethodCallExpression>) list, i, qe, operand1, ref source);
            if (expression1 != null)
              return this.GetQueryExpression(expression1, out throwIfSequenceIsEmpty, out throwIfSequenceNotSingle, out projection, ref source, ref linkLookups);
            break;
          case "SelectMany":
            if (linkLookups != null && !flag)
              linkLookups.Clear();
            this.TranslateEntityName(qe, expression, mce);
            LambdaExpression operand2 = (mce.Arguments[1] as UnaryExpression).Operand as LambdaExpression;
            return this.GetQueryExpression(this.TranslateSelectMany((IList<MethodCallExpression>) list, i, qe, operand2, ref source), out throwIfSequenceIsEmpty, out throwIfSequenceNotSingle, out projection, ref source, ref linkLookups);
          case "Skip":
            skipVal = new int?((int) (mce.Arguments[1] as ConstantExpression).Value);
            if (skipVal.HasValue)
            {
              nullable = skipVal;
              int num = 0;
              if (nullable.GetValueOrDefault() < num & nullable.HasValue)
              {
                this.ThrowException((Exception) new NotSupportedException("Skip operator does not support negative values."));
                break;
              }
              break;
            }
            break;
          case "Take":
            takeVal = new int?((int) (mce.Arguments[1] as ConstantExpression).Value);
            if (takeVal.HasValue)
            {
              nullable = takeVal;
              int num = 0;
              if (nullable.GetValueOrDefault() <= num & nullable.HasValue)
              {
                this.ThrowException((Exception) new NotSupportedException("Take/Top operators only support positive values."));
                break;
              }
              break;
            }
            break;
        }
      }
      if (projection != null)
      {
        this.TranslateSelect(qe, projection.Expression, (IEnumerable<QueryProvider.LinkLookup>) linkLookups);
        this.FixOrderBy(qe, projection.Expression);
      }
      if (!this.BuildPagingInfo(qe, skipVal, takeVal))
        this.ThrowException((Exception) new NotSupportedException("The 'Skip' value must be a multiple of the 'Take/Top' value."));
      this.FixEntityName(qe, expression);
      this.FixColumnSet(qe);
      return qe;
    }

    protected virtual bool BuildPagingInfo(QueryExpression qe, int? skipVal, int? takeVal)
    {
      if (!skipVal.HasValue && !takeVal.HasValue)
        return true;
      if (qe.PageInfo == null)
        qe.PageInfo = new PagingInfo();
      if (skipVal.HasValue && skipVal.Value > 0)
        qe.PageInfo.PageNumber = skipVal.Value;
      if (takeVal.HasValue && takeVal.Value > 0)
        qe.PageInfo.Count = takeVal.Value;
      return true;
    }

    protected virtual void FixOrderBy(QueryExpression qe, LambdaExpression exp)
    {
    }

    protected virtual void FixEntityName(QueryExpression qe, Expression expression) => this.TranslateEntityName(qe, expression, (MethodCallExpression) null);

    protected virtual void FixColumnSet(QueryExpression qe) => qe.ColumnSet = qe.ColumnSet == null || qe.ColumnSet.Columns.Count == 0 ? new ColumnSet(true) : qe.ColumnSet;

    private void TranslateJoin(
      QueryExpression qe,
      IList<MethodCallExpression> methods,
      ref int i,
      out QueryProvider.Projection projection,
      out List<QueryProvider.LinkLookup> linkLookups)
    {
      int num = 0;
      List<Tuple<string, string, LinkEntity, string>> source = (List<Tuple<string, string, LinkEntity, string>>) null;
      do
      {
        MethodCallExpression method = methods[i];
        projection = new QueryProvider.Projection(method.Method.Name, (method.Arguments[4] as UnaryExpression).Operand as LambdaExpression);
        string str;
        string environment;
        if (i < methods.Count - 1)
        {
          environment = this.GetEnvironmentForParameter(projection.Expression, 0);
          str = this.GetEnvironmentForParameter(projection.Expression, 1);
        }
        else
          environment = str = (string) null;
        string alias = (string) null;
        LambdaExpression operand1 = (method.Arguments[2] as UnaryExpression).Operand as LambdaExpression;
        string name1 = operand1.Parameters.First<ParameterExpression>().Name;
        Expression entityExpression = this.FindValidEntityExpression(operand1.Body, "join");
        string attributeName1 = this.TranslateExpressionToAttributeName(entityExpression, false, out alias);
        LambdaExpression operand2 = (method.Arguments[3] as UnaryExpression).Operand as LambdaExpression;
        string name2 = operand2.Parameters.First<ParameterExpression>().Name;
        string attributeName2 = this.TranslateExpressionToAttributeName(this.FindValidEntityExpression(operand2.Body, "join"), false, out alias);
        string entityLogicalName = ((method.Arguments[1] as ConstantExpression).Value as IEntityQuery).EntityLogicalName;
        LinkEntity linkEntity1;
        if (source == null)
        {
          qe.EntityName = ((method.Arguments[0] as ConstantExpression).Value as IEntityQuery).EntityLogicalName;
          source = new List<Tuple<string, string, LinkEntity, string>>()
          {
            new Tuple<string, string, LinkEntity, string>(environment, environment, (LinkEntity) null, name1)
          };
          linkEntity1 = qe.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner);
        }
        else
        {
          if (environment != null)
            source = source.Select<Tuple<string, string, LinkEntity, string>, Tuple<string, string, LinkEntity, string>>((Func<Tuple<string, string, LinkEntity, string>, Tuple<string, string, LinkEntity, string>>) (l => new Tuple<string, string, LinkEntity, string>(l.Item1, environment + "." + l.Item2, l.Item3, l.Item4))).ToList<Tuple<string, string, LinkEntity, string>>();
          string parentMember = this.GetUnderlyingMemberExpression(entityExpression).Member.Name;
          LinkEntity linkEntity2 = source.Single<Tuple<string, string, LinkEntity, string>>((Func<Tuple<string, string, LinkEntity, string>, bool>) (l => l.Item1 == parentMember)).Item3;
          linkEntity1 = linkEntity2 == null ? qe.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner) : linkEntity2.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner);
        }
        linkEntity1.EntityAlias = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}_{1}", (object) name2, (object) num++);
        source.Add(new Tuple<string, string, LinkEntity, string>(str, str, linkEntity1, name2));
        ++i;
      }
      while (i < methods.Count && methods[i].Method.Name == "Join");
      --i;
      linkLookups = source.Select<Tuple<string, string, LinkEntity, string>, QueryProvider.LinkLookup>((Func<Tuple<string, string, LinkEntity, string>, QueryProvider.LinkLookup>) (l => new QueryProvider.LinkLookup(l.Item4, l.Item2, l.Item3))).ToList<QueryProvider.LinkLookup>();
    }

    private void TranslateGroupJoin(
      QueryExpression qe,
      IList<MethodCallExpression> methods,
      ref int i,
      out QueryProvider.Projection projection,
      out List<QueryProvider.LinkLookup> linkLookups)
    {
      MethodCallExpression method1 = methods[i];
      List<QueryProvider.LinkLookup> linkLookups1;
      this.TranslateJoin(qe, methods, ref i, out projection, out linkLookups1);
      ++i;
      if (i + 1 > methods.Count || !this.IsValidLeftOuterSelectManyExpression(methods[i]))
        this.ThrowException((Exception) new NotSupportedException("The 'GroupJoin' operation must be followed by a 'SelectMany' operation where the collection selector is invoking the 'DefaultIfEmpty' method."));
      MethodCallExpression method2 = methods[i];
      LambdaExpression expression;
      if (method2.Arguments.Count == 3)
      {
        expression = (method2.Arguments[2] as UnaryExpression).Operand as LambdaExpression;
      }
      else
      {
        ParameterExpression parameter1 = ((method2.Arguments[1] as UnaryExpression).Operand as LambdaExpression).Parameters[0];
        ParameterExpression parameter2 = ((method1.Arguments[3] as UnaryExpression).Operand as LambdaExpression).Parameters[0];
        expression = Expression.Lambda((Expression) parameter2, parameter1, parameter2);
      }
      projection = new QueryProvider.Projection(method2.Method.Name, expression);
      string environmentForParameter1 = this.GetEnvironmentForParameter(projection.Expression, 0);
      string environmentForParameter2 = this.GetEnvironmentForParameter(projection.Expression, 1);
      linkLookups = new List<QueryProvider.LinkLookup>()
      {
        new QueryProvider.LinkLookup(linkLookups1[0].ParameterName, environmentForParameter1 != null ? string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}.{1}", (object) environmentForParameter1, (object) linkLookups1[0].Environment) : linkLookups1[0].Environment, linkLookups1[0].Link, linkLookups1[0].Environment),
        new QueryProvider.LinkLookup(linkLookups1[1].ParameterName, environmentForParameter2, linkLookups1[1].Link)
      };
      linkLookups1[1].Link.JoinOperator = JoinOperator.LeftOuter;
    }

    private bool IsValidLeftOuterSelectManyExpression(MethodCallExpression mce) => !(mce.Method.Name != "SelectMany") && mce.Arguments[1] is UnaryExpression unaryExpression1 && unaryExpression1.Operand is LambdaExpression operand1 && operand1.Body is MethodCallExpression body && !(body.Method.Name != "DefaultIfEmpty") && body.Arguments.Count == 1 && (mce.Arguments.Count == 2 || mce.Arguments.Count == 3 && mce.Arguments[2] is UnaryExpression unaryExpression2 && unaryExpression2.Operand is LambdaExpression operand2 && operand2.Parameters.Count == 2);

    private string GetEnvironmentForParameter(LambdaExpression projection, int index)
    {
      if (!(projection.Body is NewExpression body))
        return (string) null;
      ParameterExpression parameter = projection.Parameters[index];
      ReadOnlyCollection<Expression> arguments = body.Arguments;
      Expression expression = arguments.FirstOrDefault<Expression>((Func<Expression, bool>) (arg => arg == parameter));
      if (expression == null)
        return (string) null;
      int index1 = arguments.IndexOf(expression);
      return body.Members[index1].Name;
    }

    private ConditionOperator NegateOperator(ConditionOperator op) => QueryProvider._operatorNegationLookup[op];

    private LogicalOperator NegateOperator(LogicalOperator op) => QueryProvider._logicalOperatorNegationLookup[op];

    private void TranslateWhere(
      QueryExpression qe,
      string parameterName,
      Expression exp,
      List<QueryProvider.LinkLookup> linkLookups)
    {
      this.TranslateWhereBoolean(parameterName, exp, (QueryProvider.FilterExpressionWrapper) null, this.GetFilter(parameterName, qe, linkLookups), linkLookups, (BinaryExpression) null, false);
    }

    private void TranslateWhere(
      string parameterName,
      BinaryExpression be,
      QueryProvider.FilterExpressionWrapper parentFilter,
      Func<Expression, QueryProvider.FilterExpressionWrapper> getFilter,
      List<QueryProvider.LinkLookup> linkLookups,
      bool negate)
    {
      if (QueryProvider._booleanLookup.ContainsKey(be.NodeType))
      {
        parentFilter = this.GetFilter(this.FindEntityExpression(be.Left), parentFilter, getFilter);
        QueryProvider.FilterExpressionWrapper parentFilter1 = new QueryProvider.FilterExpressionWrapper(parentFilter.Filter.AddFilter(QueryProvider._booleanLookup[be.NodeType]), parentFilter.Alias);
        parentFilter1.Filter.FilterOperator = negate ? this.NegateOperator(parentFilter1.Filter.FilterOperator) : parentFilter1.Filter.FilterOperator;
        this.TranslateWhereBoolean(parameterName, be.Left, parentFilter1, getFilter, linkLookups, be, negate);
        this.TranslateWhereBoolean(parameterName, be.Right, parentFilter1, getFilter, linkLookups, be, negate);
      }
      else
      {
        if (!QueryProvider._conditionLookup.ContainsKey(be.NodeType))
          return;
        bool negate1 = negate;
        if (this.TranslateWhere(be.Left, ref negate1) is MethodCallExpression exp && (exp.Method.Name == "Compare" || ((IEnumerable<string>) QueryProvider._supportedMethods).Contains<string>(exp.Method.Name)))
          this.TranslateWhereBoolean(parameterName, (Expression) exp, parentFilter, getFilter, linkLookups, be, negate1);
        else
          this.TranslateWhereCondition(be, parentFilter, getFilter, this.GetLinkLookup(parameterName, linkLookups), negate);
      }
    }

    protected virtual Expression TranslateWhere(Expression exp, ref bool negate)
    {
      if (!(exp is UnaryExpression unaryExpression) || unaryExpression.NodeType != ExpressionType.Not)
        return exp;
      negate = !negate;
      return this.TranslateWhere(unaryExpression.Operand, ref negate);
    }

    protected virtual void TranslateWhereBoolean(
      string parameterName,
      Expression exp,
      QueryProvider.FilterExpressionWrapper parentFilter,
      Func<Expression, QueryProvider.FilterExpressionWrapper> getFilter,
      List<QueryProvider.LinkLookup> linkLookups,
      BinaryExpression parent,
      bool negate)
    {
      BinaryExpression be = exp as BinaryExpression;
      UnaryExpression unaryExpression = exp as UnaryExpression;
      MethodCallExpression mce = exp as MethodCallExpression;
      if (be != null)
      {
        if (be.Left is ConstantExpression left && (be.NodeType == ExpressionType.AndAlso && object.Equals(left.Value, (object) true) || be.NodeType == ExpressionType.OrElse && object.Equals(left.Value, (object) false)))
          this.TranslateWhereBoolean(parameterName, be.Right, parentFilter, getFilter, linkLookups, parent, negate);
        else
          this.TranslateWhere(parameterName, be, parentFilter, getFilter, linkLookups, negate);
      }
      else if (mce != null)
        this.TranslateWhereMethodCall(mce, parentFilter, getFilter, this.GetLinkLookup(parameterName, linkLookups), parent, negate);
      else if (unaryExpression != null)
      {
        if (unaryExpression.NodeType == ExpressionType.Convert)
        {
          this.TranslateWhereBoolean(parameterName, unaryExpression.Operand, parentFilter, getFilter, linkLookups, parent, negate);
        }
        else
        {
          if (unaryExpression.NodeType != ExpressionType.Not)
            return;
          this.TranslateWhereBoolean(parameterName, unaryExpression.Operand, parentFilter, getFilter, linkLookups, parent, !negate);
        }
      }
      else
      {
        if (!(exp.Type == typeof (bool)))
          return;
        this.TranslateWhere(parameterName, Expression.Equal(exp, (Expression) Expression.Constant((object) true)), parentFilter, getFilter, linkLookups, negate);
      }
    }

    private string GetLinkEntityAlias(
      Expression expression,
      Func<Expression, QueryProvider.LinkLookup> getLinkLookup)
    {
      string linkEntityAlias = (string) null;
      QueryProvider.LinkLookup linkLookup = getLinkLookup(expression);
      if (linkLookup != null && linkLookup.Link != null)
        linkEntityAlias = linkLookup.Link.EntityAlias;
      return linkEntityAlias;
    }

    private void TranslateWhereCondition(
      BinaryExpression be,
      QueryProvider.FilterExpressionWrapper parentFilter,
      Func<Expression, QueryProvider.FilterExpressionWrapper> getFilter,
      Func<Expression, QueryProvider.LinkLookup> getLinkLookup,
      bool negate)
    {
      Expression entityExpression = this.FindValidEntityExpression(be.Left);
      string alias = (string) null;
      string attributeName = this.TranslateExpressionToAttributeName(entityExpression, false, out alias);
      object conditionValue = this.TranslateExpressionToConditionValue(be.Right);
      string linkEntityAlias = this.GetLinkEntityAlias(entityExpression, getLinkLookup);
      ConditionExpression condition = (ConditionExpression) null;
      if (conditionValue != null)
        condition = new ConditionExpression(linkEntityAlias, attributeName, QueryProvider._conditionLookup[be.NodeType], conditionValue);
      else if (be.NodeType == ExpressionType.Equal)
        condition = new ConditionExpression(linkEntityAlias, attributeName, ConditionOperator.Null);
      else if (be.NodeType == ExpressionType.NotEqual)
        condition = new ConditionExpression(linkEntityAlias, attributeName, ConditionOperator.NotNull);
      else
        this.ThrowException((Exception) new NotSupportedException("Invalid 'where' condition."));
      condition.Operator = negate ? this.NegateOperator(condition.Operator) : condition.Operator;
      this.AddCondition(this.GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
    }

    private void TranslateWhereMethodCall(
      MethodCallExpression mce,
      QueryProvider.FilterExpressionWrapper parentFilter,
      Func<Expression, QueryProvider.FilterExpressionWrapper> getFilter,
      Func<Expression, QueryProvider.LinkLookup> getLinkLookup,
      BinaryExpression parent,
      bool negate)
    {
      string alias = (string) null;
      if (((IEnumerable<string>) QueryProvider._supportedMethods).Contains<string>(mce.Method.Name) && mce.Arguments.Count == 1)
      {
        Expression entityExpression = this.FindValidEntityExpression(mce.Object);
        string linkEntityAlias = this.GetLinkEntityAlias(entityExpression, getLinkLookup);
        string attributeName = this.TranslateExpressionToAttributeName(entityExpression, false, out alias);
        object conditionValue = this.TranslateExpressionToConditionValue(mce.Arguments[0]);
        if (parent != null)
        {
          if (parent.NodeType == ExpressionType.NotEqual)
            negate = !negate;
          if ((parent.NodeType == ExpressionType.Equal || parent.NodeType == ExpressionType.NotEqual) && object.Equals(this.TranslateExpressionToConditionValue(parent.Right), (object) false))
            negate = !negate;
        }
        ConditionExpression condition = this.TranslateConditionMethodExpression(mce, attributeName, conditionValue);
        condition.EntityName = linkEntityAlias;
        condition.Operator = negate ? this.NegateOperator(condition.Operator) : condition.Operator;
        this.AddCondition(this.GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
      }
      else if (mce.Method.Name == "Compare" && mce.Arguments.Count == 2)
      {
        Expression entityExpression = this.FindValidEntityExpression(mce.Arguments[0]);
        string linkEntityAlias = this.GetLinkEntityAlias(entityExpression, getLinkLookup);
        string attributeName = this.TranslateExpressionToAttributeName(entityExpression, false, out alias);
        object conditionValue = this.TranslateExpressionToConditionValue(mce.Arguments[1]);
        ConditionOperator conditionOperator;
        if (parent == null || !object.Equals(this.TranslateExpressionToConditionValue(parent.Right), (object) 0) || !QueryProvider._conditionLookup.TryGetValue(parent.NodeType, out conditionOperator))
          return;
        ConditionExpression condition = new ConditionExpression(linkEntityAlias, attributeName, conditionOperator, conditionValue);
        condition.Operator = negate ? this.NegateOperator(condition.Operator) : condition.Operator;
        this.AddCondition(this.GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
      }
      else if (mce.Method.Name == "Like" && mce.Arguments.Count == 2)
      {
        Expression entityExpression = this.FindValidEntityExpression(mce.Arguments[0]);
        string linkEntityAlias = this.GetLinkEntityAlias(entityExpression, getLinkLookup);
        string attributeName1 = this.TranslateExpressionToAttributeName(entityExpression, false, out alias);
        object conditionValue = this.TranslateExpressionToConditionValue(mce.Arguments[1]);
        string attributeName2 = attributeName1;
        object obj = conditionValue;
        ConditionExpression condition = new ConditionExpression(linkEntityAlias, attributeName2, ConditionOperator.Like, obj);
        condition.Operator = negate ? this.NegateOperator(condition.Operator) : condition.Operator;
        this.AddCondition(this.GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
      }
      else
      {
        if (parent != null && !QueryProvider._booleanLookup.ContainsKey(parent.NodeType) || !(mce.Type.GetUnderlyingType() == typeof (bool)))
          return;
        Expression entityExpression = this.FindValidEntityExpression((Expression) mce);
        ConditionExpression condition = new ConditionExpression(this.GetLinkEntityAlias(entityExpression, getLinkLookup), this.TranslateExpressionToAttributeName(entityExpression, false, out alias), ConditionOperator.Equal, (object) true);
        condition.Operator = negate ? this.NegateOperator(condition.Operator) : condition.Operator;
        this.AddCondition(this.GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
      }
    }

    private ConditionExpression TranslateConditionMethodExpression(
      MethodCallExpression mce,
      string attributeName,
      object value)
    {
      ConditionExpression conditionExpression = (ConditionExpression) null;
      switch (mce.Method.Name)
      {
        case "Equals":
          conditionExpression = value == null ? new ConditionExpression(attributeName, ConditionOperator.Null) : new ConditionExpression(attributeName, ConditionOperator.Equal, value);
          break;
        case "Contains":
          conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, (object) ("%" + value?.ToString() + "%"));
          break;
        case "StartsWith":
          conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, (object) (value?.ToString() + "%"));
          break;
        case "EndsWith":
          conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, (object) ("%" + value?.ToString()));
          break;
        default:
          this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The method '{0}' is not supported.", (object) mce.Method.Name)));
          break;
      }
      return conditionExpression;
    }

    private void AddCondition(
      QueryProvider.FilterExpressionWrapper filter,
      ConditionExpression condition,
      string alias)
    {
      if (filter.Alias != alias)
        this.ThrowException((Exception) new NotSupportedException("filter conditions of different entity types, in the same expression, are not supported"));
      filter.Filter.AddCondition(condition);
    }

    private QueryProvider.FilterExpressionWrapper GetFilter(
      Expression entityExpression,
      QueryProvider.FilterExpressionWrapper parentFilter,
      Func<Expression, QueryProvider.FilterExpressionWrapper> getFilter)
    {
      return parentFilter != null ? parentFilter : getFilter(entityExpression);
    }

    protected virtual Func<Expression, QueryProvider.LinkLookup> GetLinkLookup(
      string parameterName,
      List<QueryProvider.LinkLookup> linkLookups)
    {
      return (Func<Expression, QueryProvider.LinkLookup>) (exp =>
      {
        string expName = this.GetUnderlyingParameterExpressionName(exp);
        return linkLookups.SingleOrDefault<QueryProvider.LinkLookup>((Func<QueryProvider.LinkLookup, bool>) (link =>
        {
          string str = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}.{1}", (object) parameterName, (object) link.Environment);
          if (expName == str)
            return true;
          return expName.StartsWith(str) && expName[str.Length] == '.';
        }));
      });
    }

    protected virtual Func<Expression, QueryProvider.FilterExpressionWrapper> GetFilter(
      string parameterName,
      QueryExpression qe,
      List<QueryProvider.LinkLookup> linkLookups)
    {
      return (Func<Expression, QueryProvider.FilterExpressionWrapper>) (exp => new QueryProvider.FilterExpressionWrapper(qe.Criteria, (string) null));
    }

    protected virtual void TranslateOrderBy(
      QueryExpression qe,
      Expression exp,
      OrderType orderType,
      string parameterName,
      List<QueryProvider.LinkLookup> linkLookups)
    {
      if (this.IsEntityExpression(exp))
      {
        this.ValidateRootEntity("orderBy", exp, parameterName, linkLookups);
        string alias = (string) null;
        string attributeName = this.TranslateExpressionToAttributeName(exp, false, out alias);
        qe.AddOrder(attributeName, orderType);
      }
      else
        this.TranslateNonEntityExpressionOrderBy(qe, exp, orderType);
    }

    protected virtual void TranslateNonEntityExpressionOrderBy(
      QueryExpression qe,
      Expression exp,
      OrderType orderType)
    {
      this.ThrowException((Exception) new NotSupportedException("The 'orderBy' call must specify property names."));
    }

    private void ValidateRootEntity(
      string operationName,
      Expression exp,
      string parameterName,
      List<QueryProvider.LinkLookup> linkLookups)
    {
      if (linkLookups == null)
        return;
      string parameterExpressionName = this.GetUnderlyingParameterExpressionName(exp);
      QueryProvider.LinkLookup linkLookup = linkLookups.SingleOrDefault<QueryProvider.LinkLookup>((Func<QueryProvider.LinkLookup, bool>) (l => l.Link == null));
      if (linkLookup == null || !(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}.{1}", (object) parameterName, (object) linkLookup.Environment) != parameterExpressionName))
        return;
      this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' expression is limited to invoking the '{1}' parameter.", (object) operationName, (object) linkLookup.ParameterName)));
    }

    private Expression TranslateSelect(
      IList<MethodCallExpression> methods,
      int i,
      QueryExpression qe,
      LambdaExpression exp,
      ref QueryProvider.NavigationSource source)
    {
      Expression subExpression = this.TranslateSelect(exp, qe, ref source);
      return subExpression == null ? (Expression) null : this.MergeSubExpression(subExpression, methods, i);
    }

    private Expression TranslateSelect(
      LambdaExpression exp,
      QueryExpression qe,
      ref QueryProvider.NavigationSource source)
    {
      if (qe.Criteria.Conditions.Count != 1 || qe.Criteria.Conditions[0].Values.Count != 1 || !(qe.Criteria.Conditions[0].Values[0] is Guid))
        return (Expression) null;
      ConditionExpression condition = qe.Criteria.Conditions[0];
      EntityReference target = new EntityReference(qe.EntityName, (Guid) condition.Values[0]);
      Relationship relationship;
      IQueryable relationshipQuery = this.GetSelectRelationshipQuery(qe, exp, true, out relationship);
      if (relationshipQuery != null)
      {
        source = new QueryProvider.NavigationSource(target, relationship);
        return relationshipQuery.Expression;
      }
      source = (QueryProvider.NavigationSource) null;
      return (Expression) null;
    }

    private void TranslateSelect(
      QueryExpression qe,
      LambdaExpression exp,
      IEnumerable<QueryProvider.LinkLookup> linkLookups)
    {
      string parameterName = exp.Parameters[0].Name;
      foreach (QueryProvider.EntityColumn column in this.TraverseSelect(exp.Body))
      {
        if (linkLookups != null)
        {
          string expName = column.ParameterName;
          QueryProvider.LinkLookup linkLookup1 = linkLookups.SingleOrDefault<QueryProvider.LinkLookup>((Func<QueryProvider.LinkLookup, bool>) (l => string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}.{1}", (object) parameterName, (object) l.Environment) == expName));
          if (linkLookup1 != null && linkLookup1.Link != null)
          {
            this.TranslateSelect(column, linkLookup1.Link.Columns);
            continue;
          }
          if (linkLookup1 == null && exp.Parameters.Count > 1)
          {
            string name = exp.Parameters[1].Name;
            QueryProvider.LinkLookup linkLookup2 = column.ParameterName == name ? linkLookups.Last<QueryProvider.LinkLookup>() : (!(column.ParameterName == parameterName) || linkLookups.Count<QueryProvider.LinkLookup>() != 2 ? (QueryProvider.LinkLookup) null : linkLookups.First<QueryProvider.LinkLookup>());
            if (linkLookup2 != null && linkLookup2.Link != null)
            {
              this.TranslateSelect(column, linkLookup2.Link.Columns);
              continue;
            }
          }
        }
        this.TranslateSelect(column, qe.ColumnSet);
      }
    }

    private void TranslateSelect(QueryProvider.EntityColumn column, ColumnSet columnSet)
    {
      if (column.AllColumns)
      {
        columnSet.AllColumns = true;
      }
      else
      {
        if (columnSet.AllColumns || columnSet.Columns.Contains(column.Column))
          return;
        columnSet.AddColumn(column.Column);
      }
    }

    private IEnumerable<QueryProvider.EntityColumn> TraverseSelect(
      Expression exp)
    {
      QueryProvider.EntityColumn entityColumn1 = this.TranslateSelectColumn(exp);
      if (entityColumn1 != null)
      {
        if (entityColumn1.AllColumns || entityColumn1.Column != null)
          yield return entityColumn1;
      }
      else
      {
        foreach (Expression child in exp.GetChildren())
        {
          foreach (QueryProvider.EntityColumn entityColumn2 in this.TraverseSelect(child))
            yield return entityColumn2;
        }
      }
    }

    private QueryProvider.EntityColumn TranslateSelectColumn(Expression exp)
    {
      MemberExpression memberExpression = exp as MemberExpression;
      MethodCallExpression methodCallExpression = exp as MethodCallExpression;
      ParameterExpression pe = exp as ParameterExpression;
      if (memberExpression != null && memberExpression.Expression != null && this.IsEntity(memberExpression.Expression.Type) || methodCallExpression != null && methodCallExpression.Object != null && this.IsEntity(methodCallExpression.Object.Type))
      {
        if (memberExpression != null && memberExpression.Member.DeclaringType == typeof (Entity))
          return new QueryProvider.EntityColumn();
        string alias = (string) null;
        string attributeName = this.TranslateExpressionToAttributeName(exp, true, out alias);
        if (!string.IsNullOrEmpty(attributeName))
          return new QueryProvider.EntityColumn(this.GetUnderlyingParameterExpressionName(exp), attributeName);
      }
      else
      {
        if (memberExpression != null && this.IsEntity(memberExpression.Type) || methodCallExpression != null && this.IsEntity(methodCallExpression.Type))
          return new QueryProvider.EntityColumn(exp.ToString(), true);
        if (memberExpression != null && this.IsEnumerableEntity(memberExpression.Type) || methodCallExpression != null && this.IsEnumerableEntity(methodCallExpression.Type))
          this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The expression '{0}' is an invalid column projection expression. Entity collections cannot be selected.", (object) exp)));
      }
      return this.TranslateSelectColumn(pe);
    }

    protected virtual QueryProvider.EntityColumn TranslateSelectColumn(
      ParameterExpression pe)
    {
      if (pe != null && this.IsEntity(pe.Type))
        return new QueryProvider.EntityColumn(pe.ToString(), true);
      if (pe != null && this.IsEnumerableEntity(pe.Type))
        this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The expression '{0}' is an invalid column projection expression. Entity collections cannot be selected.", (object) pe)));
      return (QueryProvider.EntityColumn) null;
    }

    private Expression TranslateSelectMany(
      IList<MethodCallExpression> methods,
      int i,
      QueryExpression qe,
      LambdaExpression exp,
      ref QueryProvider.NavigationSource source)
    {
      Expression subExpression = this.TranslateSelectMany(qe, exp, ref source);
      return subExpression == null ? (Expression) null : this.MergeSubExpression(subExpression, methods, i);
    }

    private Expression MergeSubExpression(
      Expression subExpression,
      IList<MethodCallExpression> methods,
      int i)
    {
      for (int index = i + 1; index < methods.Count; ++index)
      {
        MethodCallExpression method = methods[index];
        subExpression = (Expression) Expression.Call((Expression) null, method.Method, ((IEnumerable<Expression>) new Expression[1]
        {
          subExpression
        }).Concat<Expression>(method.Arguments.Skip<Expression>(1)));
      }
      return subExpression;
    }

    private Expression TranslateSelectMany(
      QueryExpression qe,
      LambdaExpression exp,
      ref QueryProvider.NavigationSource source)
    {
      if (qe.Criteria.Conditions.Count != 1 || qe.Criteria.Conditions[0].Values.Count != 1 || !(qe.Criteria.Conditions[0].Values[0] is Guid))
        this.ThrowException((Exception) new InvalidOperationException("A 'SelectMany' operation must be preceeded by a 'Where' operation that filters by an entity ID."));
      ConditionExpression condition = qe.Criteria.Conditions[0];
      EntityReference target = new EntityReference(qe.EntityName, (Guid) condition.Values[0]);
      Relationship relationship = (Relationship) null;
      IQueryable relationshipQuery = this.GetSelectRelationshipQuery(qe, exp, false, out relationship);
      if (relationshipQuery != null)
      {
        source = new QueryProvider.NavigationSource(target, relationship);
        return relationshipQuery.Expression;
      }
      source = (QueryProvider.NavigationSource) null;
      return (Expression) null;
    }

    protected virtual IQueryable GetSelectRelationshipQuery(
      QueryExpression qe,
      LambdaExpression exp,
      bool isSelect,
      out Relationship relationship)
    {
      if (!(this.FindEntityExpression(exp.Body) is MemberExpression entityExpression))
      {
        relationship = (Relationship) null;
        return (IQueryable) null;
      }
      RelationshipSchemaNameAttribute defaultCustomAttribute = entityExpression.Member.GetFirstOrDefaultCustomAttribute<RelationshipSchemaNameAttribute>();
      if (defaultCustomAttribute == null)
      {
        if (isSelect)
        {
          relationship = (Relationship) null;
          return (IQueryable) null;
        }
        this.ThrowException((Exception) new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The relationship property '{0}' is invalid.", (object) entityExpression.Member.Name)));
      }
      relationship = defaultCustomAttribute.Relationship;
      return this.CreateQuery(isSelect ? entityExpression.Type : entityExpression.Type.GetGenericArguments()[0]);
    }

    private Expression GetMethodCallBody(
      MethodCallExpression mce,
      out string parameterName)
    {
      if (mce.Arguments.Count <= 1)
      {
        parameterName = (string) null;
        return (Expression) null;
      }
      LambdaExpression operand = (mce.Arguments[1] as UnaryExpression).Operand as LambdaExpression;
      parameterName = operand.Parameters[0].Name;
      return operand.Body;
    }

    protected virtual string TranslateExpressionToAttributeName(
      Expression exp,
      bool isSelectExpression,
      out string alias)
    {
      alias = (string) null;
      switch (exp)
      {
        case MethodCallExpression methodCallExpression:
          return this.TranslateExpressionToValue(methodCallExpression.Method.IsStatic ? methodCallExpression.Arguments.Skip<Expression>(1).First<Expression>() : methodCallExpression.Arguments.First<Expression>()) as string;
        case MemberExpression memberExpression:
          if (memberExpression.Member != (MemberInfo) null)
          {
            MemberExpression expression1 = memberExpression.Expression as MemberExpression;
            ParameterExpression expression2 = memberExpression.Expression as ParameterExpression;
            if (expression1 != null)
            {
              AttributeLogicalNameAttribute defaultCustomAttribute = expression1.Member.GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
              if (defaultCustomAttribute != null)
                return defaultCustomAttribute.LogicalName;
            }
            else if (expression2 != null && memberExpression.Member.Name == "Id" && this.IsStaticEntity(expression2.Type))
            {
              AttributeLogicalNameAttribute defaultCustomAttribute = expression2.Type.GetProperty("Id").GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
              if (defaultCustomAttribute != null)
                return defaultCustomAttribute.LogicalName;
            }
            return memberExpression.Member.GetLogicalName();
          }
          break;
      }
      this.ThrowException((Exception) new InvalidOperationException("Cannot determine the attribute name."));
      return (string) null;
    }

    protected virtual bool IsEnumerableEntity(Type type)
    {
      if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof (IEnumerable<>))
        return false;
      Type[] genericArguments = type.GetGenericArguments();
      return genericArguments.Length == 1 && this.IsEntity(genericArguments[0]);
    }

    private static bool IsAnonymousType(Type type) => ((IEnumerable<object>) type.GetCustomAttributes(typeof (CompilerGeneratedAttribute), false)).Any<object>() & type.FullName.Contains("AnonymousType");

    protected virtual bool IsEntity(Type type) => this.IsDynamicEntity(type) || this.IsStaticEntity(type);

    protected virtual bool IsDynamicEntity(Type type) => type.IsA<Entity>();

    private bool IsStaticEntity(Type type) => type.GetLogicalName() != null;

    protected virtual Expression FindValidEntityExpression(
      Expression exp,
      string operation = "where")
    {
      if (exp is UnaryExpression unaryExpression && (unaryExpression.NodeType == ExpressionType.Convert || unaryExpression.NodeType == ExpressionType.TypeAs))
        return this.FindValidEntityExpression(unaryExpression.Operand, operation);
      if (exp is NewExpression newExpression && newExpression.Type == typeof (EntityReference) && newExpression.Arguments.Count >= 2)
        return this.FindValidEntityExpression(newExpression.Arguments[1], operation);
      if (this.IsEntityExpression(exp))
        return exp;
      switch (exp)
      {
        case MemberExpression memberExpression when ((IEnumerable<string>) QueryProvider._validProperties).Contains<string>(memberExpression.Member.Name):
          return this.FindValidEntityExpression(memberExpression.Expression, operation);
        case MethodCallExpression methodCallExpression when ((IEnumerable<string>) QueryProvider._validMethods).Contains<string>(methodCallExpression.Method.Name):
          return this.FindValidEntityExpression(methodCallExpression.Object, operation);
        default:
          this.ThrowException((Exception) new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Invalid '{0}' condition. An entity member is invoking an invalid property or method.", (object) operation)));
          return (Expression) null;
      }
    }

    protected Expression FindEntityExpression(Expression exp) => exp.FindPreorder(new Predicate<Expression>(this.IsEntityExpression));

    protected virtual bool IsEntityExpression(Expression e)
    {
      MemberExpression me = e as MemberExpression;
      if (e is MethodCallExpression methodCallExpression)
      {
        if (methodCallExpression.Object != null)
          return this.IsDynamicEntity(methodCallExpression.Object.Type);
        if (methodCallExpression.Method.IsStatic)
          return this.IsDynamicEntity(methodCallExpression.Arguments[0].Type);
      }
      else if (me != null)
        return this.IsEntityMemberExpression(me);
      return false;
    }

    protected virtual bool IsEntityMemberExpression(MemberExpression me) => me.Member != (MemberInfo) null && this.IsEntity(me.Member.DeclaringType);

    private MemberExpression GetUnderlyingMemberExpression(Expression exp)
    {
      MemberExpression memberExpression = exp as MemberExpression;
      MethodCallExpression methodCallExpression = exp as MethodCallExpression;
      if (memberExpression != null)
        return memberExpression.Expression as MemberExpression;
      if (methodCallExpression != null)
        return methodCallExpression.Object as MemberExpression;
      this.ThrowException((Exception) new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The expression '{0}' must be a '{1}' or a '{2}'.", (object) exp, (object) typeof (MemberExpression), (object) typeof (MethodCallExpression))));
      return (MemberExpression) null;
    }

    private string GetUnderlyingParameterExpressionName(Expression exp)
    {
      MemberExpression memberExpression = exp as MemberExpression;
      MethodCallExpression methodCallExpression = exp as MethodCallExpression;
      if (memberExpression != null)
        return memberExpression.Expression.ToString();
      if (methodCallExpression != null)
        return methodCallExpression.Object.ToString();
      this.ThrowException((Exception) new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The expression '{0}' must be a '{1}' or a '{2}'.", (object) exp, (object) typeof (MemberExpression), (object) typeof (MethodCallExpression))));
      return (string) null;
    }

    private object TranslateExpressionToValue(
      Expression exp,
      params ParameterExpression[] parameters)
    {
      if (exp is ConstantExpression constantExpression)
        return constantExpression.Value;
      if (exp is MemberExpression memberExpression && memberExpression.Expression is ConstantExpression expression)
      {
        object target = expression.Value;
        FieldInfo member1 = memberExpression.Member as FieldInfo;
        if (member1 != (FieldInfo) null)
          return this.GetFieldValue(member1, target);
        PropertyInfo member2 = memberExpression.Member as PropertyInfo;
        if (member2 != (PropertyInfo) null)
          return this.GetPropertyValue(member2, target);
      }
      return exp is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert ? this.TranslateExpressionToValue(unaryExpression.Operand) : this.DynamicInvoke(this.CompileExpression(Expression.Lambda(exp, parameters)));
    }

    [SecuritySafeCritical]
    private object GetFieldValue(FieldInfo fieldInfo, object target)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
        return fieldInfo.GetValue(target);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    [SecuritySafeCritical]
    private object GetPropertyValue(PropertyInfo propertyInfo, object target)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
        return propertyInfo.GetValue(target, (object[]) null);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    private object TranslateExpressionToConditionValue(
      Expression exp,
      params ParameterExpression[] parameters)
    {
      object conditionValue = this.TranslateExpressionToValue(exp, parameters);
      EntityReference entityReference = conditionValue as EntityReference;
      OptionSetValue optionSetValue = conditionValue as OptionSetValue;
      Money money = conditionValue as Money;
      if (entityReference != null)
        conditionValue = (object) entityReference.Id;
      else if (money != null)
        conditionValue = (object) money.Value;
      else if (optionSetValue != null)
        conditionValue = (object) optionSetValue.Value;
      else if (conditionValue != null && conditionValue.GetType().IsEnum)
        conditionValue = (object) (int) conditionValue;
      return conditionValue;
    }

    protected virtual void TranslateEntityName(
      QueryExpression qe,
      Expression expression,
      MethodCallExpression mce)
    {
      if (qe.EntityName != null)
        return;
      ConstantExpression constantExpression = expression is MethodCallExpression ? expression.GetMethodsPreorder().Last<MethodCallExpression>().Arguments[0] as ConstantExpression : expression as ConstantExpression;
      if (constantExpression == null || !(constantExpression.Value is IEntityQuery entityQuery))
        return;
      qe.EntityName = entityQuery.EntityLogicalName;
    }

    protected virtual void ThrowException(Exception exception) => throw exception;

    protected sealed class NavigationSource
    {
      public EntityReference Target { get; private set; }

      public Relationship Relationship { get; private set; }

      public NavigationSource(EntityReference target, Relationship relationship)
      {
        this.Target = target;
        this.Relationship = relationship;
      }
    }

    protected sealed class FilterExpressionWrapper
    {
      public FilterExpression Filter { get; private set; }

      public string Alias { get; private set; }

      public FilterExpressionWrapper(FilterExpression filter, string alias)
      {
        this.Filter = filter != null ? filter : throw new ArgumentNullException(nameof (filter));
        this.Alias = alias;
      }
    }

    protected sealed class LinkLookup
    {
      public string ParameterName { get; private set; }

      public string Environment { get; private set; }

      public LinkEntity Link { get; private set; }

      public string SelectManyEnvironment { get; private set; }

      public LinkLookup(string parameterName, string environment, LinkEntity link)
        : this(parameterName, environment, link, (string) null)
      {
      }

      public LinkLookup(
        string parameterName,
        string environment,
        LinkEntity link,
        string selectManyEnvironment)
      {
        this.ParameterName = parameterName;
        this.Environment = environment;
        this.Link = link;
        this.SelectManyEnvironment = selectManyEnvironment;
      }
    }

    protected sealed class Projection
    {
      public string MethodName { get; private set; }

      public LambdaExpression Expression { get; private set; }

      public Projection(string methodName, LambdaExpression expression)
      {
        this.MethodName = methodName;
        this.Expression = expression;
      }
    }

    protected sealed class EntityColumn
    {
      public string ParameterName { get; private set; }

      public string Column { get; private set; }

      public bool AllColumns { get; private set; }

      public EntityColumn()
      {
      }

      public EntityColumn(string parameterName, string column)
      {
        this.ParameterName = parameterName;
        this.Column = column;
      }

      public EntityColumn(string parameterName, bool allColumns)
      {
        this.ParameterName = parameterName;
        this.AllColumns = allColumns;
      }
    }
  }
}
