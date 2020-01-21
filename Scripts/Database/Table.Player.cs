// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Database;
using System;
using SQLite;

namespace Wovencode.Database
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
	
		// -------------------------------------------------------------------------------
		// TablePlayer
		// -------------------------------------------------------------------------------
		partial class TablePlayer
		{
			[PrimaryKey]
			[Collation("NOCASE")]
			public string name 			{ get; set; }
			public string username		{ get; set; }
			public DateTime created 	{ get; set; }
			public DateTime lastlogin 	{ get; set; }
			public bool deleted 		{ get; set; }
			public bool banned 			{ get; set; }
			public bool online 			{ get; set; }
			public DateTime lastsaved 	{ get; set; }
			public int token			{ get; set; }
		}
	
	}
	
	// -------------------------------------------------------------------------------
	
}