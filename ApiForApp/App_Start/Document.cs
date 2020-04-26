using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSS;
using System.Data;

public class Document
{
    public long DocumentID { get; set; }
    public Guid ObjectGuid { get; set; }
    public string DocumentTitle { get; set; }
    public DateTime DocumentDate { get; set; }
    public int DocumentCategoryID { get; set; }
    public int DocumentFieldID { get; set; }
    public int DocumentTypeID { get; set; }
    public int DocumentExigentID { get; set; }
    public string SymbolNumber { get; set; }
    public string Signer { get; set; }
    public int StatusID { get; set; }
    public long EOfficeID { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdate { get; set; }

    public string InsertUpdate(out Document d)
    {
        return DBM.GetOne("usp_Document_InsertUpdate",
            new
            {
                DocumentID,
                DocumentTitle,
                DocumentDate,
                DocumentFieldID,
                DocumentTypeID,
                DocumentExigentID,
                SymbolNumber,
                Signer,
                StatusID,
                EOfficeID,
                DocumentCategoryID
            },
            out d);
    }

    public static string GetListSearch_Total(DocumentSearch ds, out int total)
    {
        return DBM.ExecStore("usp_Document_SelectSearch_Total", ds, out total);
    }
    public static string GetListSearch(DocumentSearch ds, out DataTable dt)
    {
        return DBM.ExecStore("usp_Document_SelectSearch", ds, out dt);  
    }
      
    public static string GetOneByDocumentID(long DocumentID, out Document d)
    {
        return DBM.GetOne("usp_Document_SelectByDocumentID", new { DocumentID }, out d);
    }

    public static string GetOneByGuid(Guid ObjectGuid, out long DocumentID)
    {
        return DBM.ExecStore("usp_Document_SelectByObjectGuid", new { ObjectGuid }, out DocumentID);
    }
}
public class DocumentSearch
{
    public int Top { get; set; }
    public string DocumentTitle { get; set; }
    public DateTime DocumentDateFrom { get; set; }
    public DateTime DocumentDateTo { get; set; }
    public int DocumentCategoryID { get; set; }
    public int DocumentFieldID { get; set; }
    public int DocumentTypeID { get; set; }
    public int DocumentExigentID { get; set; }
    public string SymbolNumber { get; set; }
    public string Signer { get; set; }
    public int StatusID { get; set; }
}