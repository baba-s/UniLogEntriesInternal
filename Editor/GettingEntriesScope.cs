using System;

namespace UniLogEntriesInternal
{
	/// <summary>
	/// ログエントリを取得するスコープを管理するクラス
	/// </summary>
	public sealed class GettingEntriesScope : IDisposable
	{
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// ログエントリを取得する前に呼び出します
		/// </summary>
		public GettingEntriesScope()
		{
			LogEntries.StartGettingEntries();
		}

		/// <summary>
		/// ログエントリを取得した後に呼び出します
		/// </summary>
		public void Dispose()
		{
			LogEntries.EndGettingEntries();
		}
	}
}