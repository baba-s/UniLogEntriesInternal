namespace UniLogEntriesInternal
{
	/// <summary>
	/// UnityEditor.LogEntry にアクセスできるようにするためのクラス
	/// </summary>
	public partial class LogEntry
	{
		//================================================================================
		// 変数
		//================================================================================
		public int    column;
		public string file;
		public int    identifier;
		public int    instanceID;
		public int    line;
		public string message;
		public int    mode;
	}
}