using System;
using System.Collections.Generic;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Library.Documents;
using VVRuntime.VisualVault.Library.Search;
using VisualVault.Examples.AdvancedSearch.Extensions;


namespace VisualVault.Examples.AdvancedSearch.DataAccess
{
    public class DocumentSearch
    {
        private readonly LibrarySearch _librarySearch;
        private readonly Vault _vault;

        public DocumentSearch(Vault vault)
        {
            _vault = vault;
            _librarySearch = _vault.DefaultStore.Library.NewSearch();
        }

        public LibrarySearch LibrarySearch
        {
            get { return _librarySearch; }
        }

        public DocumentBindingListCollection SearchFiles(List<String> folderIds, List<SearchParameterItem> searchParameterItems, bool includeSubfolders)
        {

            var bindingListCollection = new DocumentBindingListCollection();

            try
            {

                foreach (string folderId in folderIds)
                {
                    if (folderId.IsGuid())
                    {
                        if (IsTheRoot(folderId.ToGuid()))
                        {
                            _librarySearch.SearchFolders.Clear();
                            _librarySearch.AddSearchFolder(_vault.DefaultStore.StoreID, includeSubfolders);
                            break;
                        }

                        _librarySearch.AddSearchFolder(folderId.ToGuid(), includeSubfolders);
                    }
                }

                //Guid myGroupId = mySearch.CreateNewSearchGroup(SearchLogicalOperatorType.AndOperator);

                foreach (SearchParameterItem searchParameterItem in searchParameterItems)
                {
                    _librarySearch.AddSearchParameter(searchParameterItem.SearchField, searchParameterItem.OperatorType,
                                                      searchParameterItem.SearchPhrase,
                                                      searchParameterItem.LogicalOperatorType,
                                                      searchParameterItem.SearchGroupId);
                }

                //standard document meta-data search fields for reference:
                //mySearch.AddSearchParameter("Doc ID", SearchOperatorType.Contain, searchValue, SearchLogicalOperatorType.OrOperator, myGroupId);
                //mySearch.AddSearchParameter("Full Text", SearchOperatorType.Contain, searchValue, SearchLogicalOperatorType.OrOperator, myGroupId);
                //mySearch.AddSearchParameter("File Name", SearchOperatorType.Contain, searchValue, SearchLogicalOperatorType.OrOperator, myGroupId);
                //mySearch.AddSearchParameter("Description", SearchOperatorType.Contain, searchValue, SearchLogicalOperatorType.OrOperator, myGroupId);
                //mySearch.AddSearchParameter("Folder Path", SearchOperatorType.Contain, searchValue, SearchLogicalOperatorType.OrOperator, myGroupId);
                //mySearch.AddSearchParameter("Keywords", SearchOperatorType.Contain, searchValue, SearchLogicalOperatorType.OrOperator, myGroupId);

                DocumentCollection docs = _vault.DefaultStore.Library.SearchForDocuments(_librarySearch);

                foreach(Document document in docs)
                {
                    bindingListCollection.Add(document);
                }

            }catch(Exception ex)
            {
                string message = ex.Message;
            }

            return bindingListCollection;
        }

        private Boolean IsTheRoot(Guid folderId)
        {
            Boolean result = false;
            if (folderId == _vault.DefaultStore.Library.DocumentLibraryID)
            {
                result = true;
            }
            return result;
        }

    }
}