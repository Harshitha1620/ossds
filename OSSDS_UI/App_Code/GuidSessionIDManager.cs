using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Summary description for GuidSessionIDManager
/// </summary>
public class GuidSessionIDManager : SessionIDManager
{
	public GuidSessionIDManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public override string CreateSessionID(HttpContext context)
    {
        return Guid.NewGuid().ToString();

        // Here you can create your own max 80 character unique GUID ID.
    }


    public override bool Validate(string id)
    {
        try
        {

            Guid testGuid = new Guid(id);
            if (id == testGuid.ToString())
                return true;
        }
        catch
        {
        }

        return false;
    }
}