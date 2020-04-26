using BSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DocumentCategory
{
    public long DocumentCategoryID { get; set; }
    public string DocumentCategoryName { get; set; }

    public static string GetList(out List<DocumentCategory> lt)
    {
        return DBM.GetList("usp_DocumentCategory_SelectAll", new { }, out lt);
    }
}