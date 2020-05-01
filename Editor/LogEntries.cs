using System;
using System.Reflection;
using UnityEditor;

namespace UniLogEntriesInternal
{
	/// <summary>
	/// UnityEditor.LogEntries にアクセスできるようにするためのクラス
	/// </summary>
	public static class LogEntries
	{
		//================================================================================
		// 定数
		//================================================================================
		private const BindingFlags BINDING_ATTR = BindingFlags.Static | BindingFlags.Public;

		//================================================================================
		// 変数(static readonly)
		//================================================================================
		private static readonly Assembly ms_assembly = Assembly.GetAssembly( typeof( EditorApplication ) );
		private static readonly Type     ms_type     = ms_assembly.GetType( "UnityEditor.LogEntries" );

		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// 指定されたインデックスのログエントリをダブルクリックした時の処理を呼び出します
		/// </summary>
		public static void RowGotDoubleClicked( int index )
		{
			var methodInfo = ms_type.GetMethod( nameof( RowGotDoubleClicked ), BINDING_ATTR );
			methodInfo.Invoke( null, new object[] { index } );
		}

		/// <summary>
		/// Unity エディタ左下のステータスバーに表示されているログエントリの文字列を返します
		/// </summary>
		public static string GetStatusText()
		{
			var methodInfo = ms_type.GetMethod( nameof( GetStatusText ), BINDING_ATTR );
			return ( string ) methodInfo.Invoke( null, new object[] { } );
		}

		/// <summary>
		/// ？
		/// </summary>
		public static int GetStatusMask()
		{
			var methodInfo = ms_type.GetMethod( nameof( GetStatusMask ), BINDING_ATTR );
			return ( int ) methodInfo.Invoke( null, new object[] { } );
		}

		/// <summary>
		/// ログエントリを取得する前に呼び出します
		/// </summary>
		public static int StartGettingEntries()
		{
			var methodInfo = ms_type.GetMethod( nameof( StartGettingEntries ), BINDING_ATTR );
			return ( int ) methodInfo.Invoke( null, new object[] { } );
		}

		/// <summary>
		/// Console ウィンドウの設定のオン・オフを変更します
		/// </summary>
		public static void SetConsoleFlag( ConsoleFlags bit, bool value )
		{
			var methodInfo = ms_type.GetMethod( nameof( SetConsoleFlag ), BINDING_ATTR );
			methodInfo.Invoke( null, new object[] { ( int ) bit, value } );
		}

		/// <summary>
		/// ログエントリを取得した後に呼び出します
		/// </summary>
		public static void EndGettingEntries()
		{
			var methodInfo = ms_type.GetMethod( nameof( EndGettingEntries ), BINDING_ATTR );
			methodInfo.Invoke( null, new object[] { } );
		}

		/// <summary>
		/// Console ウィンドウに出力されているログエントリの数を返します
		/// </summary>
		public static int GetCount()
		{
			var methodInfo = ms_type.GetMethod( nameof( GetCount ), BINDING_ATTR );
			return ( int ) methodInfo.Invoke( null, new object[] { } );
		}

		/// <summary>
		/// Console ウィンドウに出力されているログエントリの種類ごとの数を取得します
		/// </summary>
		public static void GetCountsByType( ref int errorCount, ref int warningCount, ref int logCount )
		{
			var parameters = new object[] { errorCount, warningCount, logCount };
			var methodInfo = ms_type.GetMethod( nameof( GetCountsByType ), BINDING_ATTR );
			methodInfo.Invoke( null, parameters );

			errorCount   = ( int ) parameters[ 0 ];
			warningCount = ( int ) parameters[ 1 ];
			logCount     = ( int ) parameters[ 2 ];
		}

		//public static void GetLinesAndModeFromEntryInternal( int row, int numberOfLines, ref int mask, [In, Out] ref string outString )
		//{
		//	var parameters = new object[] { row, numberOfLines, mask, outString };
		//	var methodInfo = ms_type.GetMethod( nameof( GetLinesAndModeFromEntryInternal ), BINDING_ATTR );
		//	methodInfo.Invoke( null, parameters );

		//	mask      = ( int ) parameters[ 2 ];
		//	outString = ( string ) parameters[ 3 ];
		//}

		/// <summary>
		/// <para>指定された行のログエントリを取得します</para>
		/// <para>この関数を実行する前に StartGettingEntries を呼び出し</para>
		/// <para>この関数を実行した後に EndGettingEntries を呼び出す必要があります</para>
		/// </summary>
		public static bool GetEntryInternal( int row, out LogEntry outputEntry )
		{
			var type        = ms_assembly.GetType( "UnityEditor.LogEntry" );
			var entry       = Activator.CreateInstance( type );
			var bindingAttr = BindingFlags.Instance | BindingFlags.Public;
			var methodInfo  = ms_type.GetMethod( nameof( GetEntryInternal ), BINDING_ATTR );
			var result      = ( bool ) methodInfo.Invoke( null, new object[] { row, entry } );

			outputEntry = new LogEntry
			{
				column     = ( int ) type.GetField( "column", bindingAttr ).GetValue( entry ),
				file       = ( string ) type.GetField( "file", bindingAttr ).GetValue( entry ),
				identifier = ( int ) type.GetField( "identifier", bindingAttr ).GetValue( entry ),
				instanceID = ( int ) type.GetField( "instanceID", bindingAttr ).GetValue( entry ),
				line       = ( int ) type.GetField( "line", bindingAttr ).GetValue( entry ),
				message    = ( string ) type.GetField( "message", bindingAttr ).GetValue( entry ),
				mode       = ( int ) type.GetField( "mode", bindingAttr ).GetValue( entry )
			};

			return result;
		}

		/// <summary>
		/// ？
		/// </summary>
		public static int GetEntryCount( int row )
		{
			var methodInfo = ms_type.GetMethod( nameof( GetEntryCount ), BINDING_ATTR );
			return ( int ) methodInfo.Invoke( null, new object[] { row } );
		}

		/// <summary>
		/// Console ウィンドウに出力されているすべてのログエントリを削除します
		/// </summary>
		public static void Clear()
		{
			var methodInfo = ms_type.GetMethod( nameof( Clear ), BINDING_ATTR );
			methodInfo.Invoke( null, new object[] { } );
		}

		/// <summary>
		/// Unity エディタ左下のステータスバーに表示されているログエントリのインデックスを返します
		/// </summary>
		public static int GetStatusViewErrorIndex()
		{
			var methodInfo = ms_type.GetMethod( nameof( GetStatusViewErrorIndex ), BINDING_ATTR );
			return ( int ) methodInfo.Invoke( null, new object[] { } );
		}

		/// <summary>
		/// <para>Unity エディタ左下のステータスバーを指定した回数クリックした時の処理を呼び出します</para>
		/// <para>1：クリック（Console ウィンドウの該当するログエントリを選択状態にする）</para>
		/// <para>2：ダブルクリック（ログエントリのスタックトレースにジャンプする）</para>
		/// </summary>
		public static void ClickStatusBar( int count )
		{
			var methodInfo = ms_type.GetMethod( nameof( ClickStatusBar ), BINDING_ATTR );
			methodInfo.Invoke( null, new object[] { count } );
		}

		//public static void AddMessageWithDoubleClickCallback( LogEntry outputEntry )
		//{
		//	var type        = ms_assembly.GetType( "UnityEditor.LogEntry" );
		//	var entry       = Activator.CreateInstance( type );
		//	var bindingAttr = BindingFlags.Instance | BindingFlags.Public;

		//	type.GetField( "column", bindingAttr ).SetValue( entry, outputEntry.column );
		//	type.GetField( "file", bindingAttr ).SetValue( entry, outputEntry.file );
		//	type.GetField( "identifier", bindingAttr ).SetValue( entry, outputEntry.identifier );
		//	type.GetField( "instanceID", bindingAttr ).SetValue( entry, outputEntry.instanceID );
		//	type.GetField( "line", bindingAttr ).SetValue( entry, outputEntry.line );
		//	type.GetField( "message", bindingAttr ).SetValue( entry, outputEntry.message );
		//	type.GetField( "mode", bindingAttr ).SetValue( entry, outputEntry.mode );

		//	var methodInfo = ms_type.GetMethod( nameof( AddMessageWithDoubleClickCallback ), BINDING_ATTR );
		//	methodInfo.Invoke( null, new object[] { entry } );
		//}
	}
}