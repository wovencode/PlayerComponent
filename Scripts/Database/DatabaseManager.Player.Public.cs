// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using wovencode;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace wovencode
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
				
		// ============================== PUBLIC METHODS =================================
		
		// -------------------------------------------------------------------------------
		// TryLoginPlayer
		// -------------------------------------------------------------------------------
		public override bool TryLoginPlayer(string _name, string _username)
		{
			
			if (!base.TryLoginPlayer(_name, _username) || !UserValid(_name, _username))
				return false;
			
			PlayerSetOnline(_name);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// TryRegisterPlayer
		// -------------------------------------------------------------------------------
		public override bool TryRegisterPlayer(string _name, string _username)
		{
		
			if (!base.TryRegisterPlayer(_name, _username) || UserExists(_name))
				return false;
			
			PlayerCreate(_name, _username);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// TrySoftDeletePlayer
		// -------------------------------------------------------------------------------
		public override bool TrySoftDeletePlayer(string _name, string _username, int _action=1)
		{
		
			if (!base.TrySoftDeletePlayer(_name, _username) || !UserValid(_name, _username))
				return false;
				
			PlayerSetDeleted(_name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// TryBanPlayer
		// -------------------------------------------------------------------------------
		public override bool TryBanPlayer(string _name, string _username, int _action=1)
		{
			
			if (!base.TryBanUser(_name, _username) || !UserValid(_name, _username))
				return false;
				
			PlayerSetBanned(_name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// PlayerCreate
		// -------------------------------------------------------------------------------
		public void PlayerCreate(string _name, string _username)
		{
			Insert(new TablePlayer{ name=_name, username=_username, created=DateTime.UtcNow, lastlogin=DateTime.Now, banned=false});
		}
		
		// -------------------------------------------------------------------------------
		// PlayerValid
		// -------------------------------------------------------------------------------
		public bool PlayerValid(string _name, string _username)
		{
			return FindWithQuery<TablePlayer>("SELECT * FROM TablePlayer WHERE name=? AND username=? AND banned=0 AND deleted=0", _name, _username) != null;
		}
		
		// -------------------------------------------------------------------------------
		// PlayerExists
		// -------------------------------------------------------------------------------
		public bool PlayerExists(string _name)
		{
			return FindWithQuery<TablePlayer>("SELECT * FROM TablePlayer WHERE name=?", _name) != null;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================