using System;

namespace VisualVault.Examples.Export
{
	#region "vvTreeNode Class'

	/// <summary>
	/// Tree node and list item classes
	/// </summary>
	public class VvTreeNode : System.Windows.Forms.TreeNode
	{
		public Guid NodeID;

		public VvTreeNode(Guid id, string text)
		{
			NodeID = id;
			this.Text = text;
		}
	}
	

	#endregion

	#region "MyListViewItem Class"

	/// <summary>
	/// List view item class with both text and ID properties
	/// </summary>
	public class MyListViewItem : System.Windows.Forms.ListViewItem
	{
		public Guid ListViewItemID;

		public MyListViewItem(Guid id, string text)
		{
			ListViewItemID = id;
			this.Text = text;
		}
	}
	

	#endregion

	#region "SupportCode Class"

	/// <summary>
	/// Static helper methods
	/// </summary>
	public class SupportCode
	{
		internal static bool IsNumeric(object ObjectToTest) 
		{ 
			if (ObjectToTest == null) 

			{
				return false; 

			}
			else 
			{ 
				double OutValue; 
				return double.TryParse(ObjectToTest.ToString().Trim(), 
					System.Globalization.NumberStyles.Any,

					System.Globalization.CultureInfo.CurrentCulture,

					out OutValue); 
			} 
		} 

		
		internal static bool IsDate(string inValue)
		{
			bool result = false;
			try 
			{
				DateTime myDT = DateTime.Parse(inValue);
				result = true;
			}
			catch
			{
				result = false;
			}
			
			return result;
			
		}

		
		internal static void ReDim(ref object[] arr, int length)
		{
			object[] arrTemp=new object[length];
			if(length>arr.Length)
			{
				Array.Copy(arr, 0, arrTemp, 0, arr.Length);
				arr = arrTemp;
			}
			else
			{
				Array.Copy(arr, 0, arrTemp, 0, length);
				arr = arrTemp;
			}
		}

		
		internal static void ReDim(ref string[] arr, int length)
		{
			string[] arrTemp=new string[length];
			if(length>arr.Length)
			{
				Array.Copy(arr, 0, arrTemp, 0, arr.Length);
				arr = arrTemp;
			}
			else
			{
				Array.Copy(arr, 0, arrTemp, 0, length);
				arr = arrTemp;
			}
		}


		internal static bool IsFileInUse(string filename)
		{
		
			bool isInUse=true;

			try
			{
				var fs = new System.IO.FileStream(filename,System.IO.FileMode.Open,System.IO.FileAccess.ReadWrite,System.IO.FileShare.None);

				if (fs.CanRead)
				{
					isInUse=false;
					fs.Close();
					System.Threading.Thread.Sleep(5 * 1000);//5 second delay
				}
				else
				{
					fs.Close();
				}
			}
			catch(Exception ex)
			{
				string exMessage=ex.Message;				
			}	

			return isInUse;
		}


	}


	#endregion
	
	#region "MyIndexFieldItem Class"

	/// <summary>
	/// IndexField item used for holding a document index field's name, value, and related file name
	/// </summary>
	public class MyIndexFieldItem : System.Windows.Forms.ListViewItem
	{
		public String IndexValue;
		public String FileName;

		public MyIndexFieldItem(string text,string indexValue,string fileName )
		{
			this.Text = text;
			this.IndexValue = indexValue;
			this.FileName = fileName;
		}
	}
	

	#endregion

	
}
