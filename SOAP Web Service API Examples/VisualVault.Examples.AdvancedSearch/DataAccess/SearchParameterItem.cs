using System;
using VVRuntime.VisualVault.Library.Search;

namespace VisualVault.Examples.AdvancedSearch.DataAccess
{
    /// <summary>
    /// Search parameters make up a search group. Each search group represents a set of search parameters within brackets.
    /// Search parameters are joined together using And/Or; search groups may also be joined together using And/Or. 
    /// </summary>
    public class SearchParameterItem
    {
        /// <summary>
        /// Document property or index field name to search against.
        /// </summary>
        public string SearchField { get; set; }

        /// <summary>
        /// The phrase to look for within the specified search field
        /// </summary>
        public string SearchPhrase { get; set; }

        /// <summary>
        /// Type of search comparison when comparing the SearchPhrase against the SearchField
        /// </summary>
        public SearchOperatorType OperatorType {get;set;}

        /// <summary>
        /// Operator used to join multiple search parameters together within a search group
        /// </summary>
        public SearchLogicalOperatorType LogicalOperatorType { get; set; }

        /// <summary>
        /// Id of the search group this search parameter belongs to. Each search parameter must belong to a search group.
        /// Only one search group is required to submit a search request although multiple groups can be joined together
        /// using And/Or.
        /// </summary>
        public Guid SearchGroupId { get; set; }
    }
}
