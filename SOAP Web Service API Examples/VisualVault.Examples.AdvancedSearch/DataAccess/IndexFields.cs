using System;
using System.Data;
using System.Data.SqlClient;
using VVRuntime.DataServices.VisualVault;

namespace VisualVault.Examples.AdvancedSearch.DataAccess
{
    public class IndexFields
    {
        internal static DataTable GetDistinctIndexFieldValuesByFieldName(string indexFieldName, string indexFieldFilterValue, ArchiveType archiveType, Guid topLevelFolderId, int rowCount, VVRuntime.VisualVault.Vault vault, string connectionStringPassword)
        {
            var dt = new DataTable();

            string sqlText = "SELECT DISTINCT TOP {0} adValue FROM Attribute_Detail ad " +
                             "INNER JOIN Category_Attributes ca ON AdCaID=CaID " +
                             "INNER JOIN FolderStore fs ON FsID = CaChID " +
                             "INNER JOIN Doc_Header dh ON AdDhID = DhID AND DhArchive={1} " +
                             "WHERE AdLabel = '{2}' ";

            string cmdText;

            if(indexFieldFilterValue.Length>0)
            {
                sqlText += "AND AdValue LIKE '%{3}%' ";
                sqlText += "AND ContainerId = '{4}' ORDER BY AdValue ASC";
                cmdText = string.Format(sqlText, rowCount, Convert.ToInt32(archiveType), indexFieldName, indexFieldFilterValue, topLevelFolderId);
                
            }else
            {
                sqlText += "AND ContainerId = '{3}' ORDER BY AdValue ASC";
                cmdText = string.Format(sqlText, rowCount, Convert.ToInt32(archiveType), indexFieldName, topLevelFolderId);
            }
           

            string connectionString = vault.Configurations.GetConnectionStringSecure(connectionStringPassword);

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@AdLabel", SqlDbType.VarChar, 255)).Value = indexFieldName;
                    cmd.Parameters.Add(new SqlParameter("@AdValue", SqlDbType.VarChar, 1024)).Value = indexFieldFilterValue;
                    cmd.Parameters.Add(new SqlParameter("@TopLevelFolderId", SqlDbType.UniqueIdentifier)).Value = topLevelFolderId;

                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

    }
}