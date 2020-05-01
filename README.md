# Uni Log Entries Internal

Console ウィンドウを操作する internal な機能を使用できるようにするパッケージ

## 使用例

```cs
using UniLogEntriesInternal;
using UnityEditor;
using UnityEngine;

public class Example : MonoBehaviour
{
    [MenuItem( "Tools/Log" )]
    private static void Log()
    {
        int count = 3;
        for ( int i = 0; i < count; i++ )
        {
            Debug.Log( "ピカチュウ" );
            Debug.Log( "ピカチュウ" );
            Debug.Log( "ピカチュウ" );
            Debug.LogWarning( "カイリュー" );
            Debug.LogWarning( "カイリュー" );
            Debug.LogError( "ヤドラン" );
        }
    }

    // 指定されたインデックスのログエントリをダブルクリックした時の処理を呼び出します
    [MenuItem( "LogEntriesInternal/" + nameof( RowGotDoubleClicked ) )]
    private static void RowGotDoubleClicked()
    {
        LogEntries.RowGotDoubleClicked( 3 );
    }

    // Unity エディタ左下のステータスバーに表示されているログエントリの文字列を返します
    [MenuItem( "LogEntriesInternal/" + nameof( GetStatusText ) )]
    private static void GetStatusText()
    {
        Debug.Log( LogEntries.GetStatusText() );
    }

    // ？
    [MenuItem( "LogEntriesInternal/" + nameof( GetStatusMask ) )]
    private static void GetStatusMask()
    {
        Debug.Log( LogEntries.GetStatusMask() );
    }

    // Console ウィンドウの設定のオン・オフを変更します
    [MenuItem( "LogEntriesInternal/" + nameof( SetConsoleFlag ) )]
    private static void SetConsoleFlag()
    {
        LogEntries.SetConsoleFlag( ConsoleFlags.ClearOnPlay | ConsoleFlags.ClearOnBuild, false );
    }

    // Console ウィンドウに出力されているログエントリの数を返します
    [MenuItem( "LogEntriesInternal/" + nameof( GetCount ) )]
    private static void GetCount()
    {
        Debug.Log( LogEntries.GetCount() );
    }

    // Console ウィンドウに出力されているログエントリの種類ごとの数を取得します
    [MenuItem( "LogEntriesInternal/" + nameof( GetCountsByType ) )]
    private static void GetCountsByType()
    {
        var errorCount   = 0;
        var warningCount = 0;
        var logCount     = 0;

        LogEntries.GetCountsByType
        (
            errorCount: ref errorCount,
            warningCount: ref warningCount,
            logCount: ref logCount
        );

        Debug.Log( errorCount );
        Debug.Log( warningCount );
        Debug.Log( logCount );
    }

    // 指定された行のログエントリを取得します
    [MenuItem( "LogEntriesInternal/" + nameof( GetEntryInternal ) )]
    private static void GetEntryInternal()
    {
        LogEntries.StartGettingEntries();
        Debug.Log( LogEntries.GetEntryInternal( 0, out var entry1 ) );
        Debug.Log( entry1.message );
        Debug.Log( entry1.file );
        Debug.Log( entry1.line );
        LogEntries.EndGettingEntries();

        using ( new GettingEntriesScope() )
        {
            Debug.Log( LogEntries.GetEntryInternal( 0, out var entry2 ) );
            Debug.Log( entry2.message );
            Debug.Log( entry2.file );
            Debug.Log( entry1.line );
        }
    }

    // ？
    [MenuItem( "LogEntriesInternal/" + nameof( GetEntryCount ) )]
    private static void GetEntryCount()
    {
        Debug.Log( LogEntries.GetEntryCount( 8 ) );
    }

    // Console ウィンドウに出力されているすべてのログエントリを削除します
    [MenuItem( "LogEntriesInternal/" + nameof( Clear ) )]
    private static void Clear()
    {
        LogEntries.Clear();
    }

    // Unity エディタ左下のステータスバーに表示されているログエントリのインデックスを返します
    [MenuItem( "LogEntriesInternal/" + nameof( GetStatusViewErrorIndex ) )]
    private static void GetStatusViewErrorIndex()
    {
        Debug.Log( LogEntries.GetStatusViewErrorIndex() );
    }

    // Unity エディタ左下のステータスバーを指定した回数クリックした時の処理を呼び出します
    // 1：クリック（Console ウィンドウの該当するログエントリを選択状態にする）
    // 2：ダブルクリック（ログエントリのスタックトレースにジャンプする）
    [MenuItem( "LogEntriesInternal/" + nameof( ClickStatusBar ) )]
    private static void ClickStatusBar()
    {
        LogEntries.ClickStatusBar( 0 );
    }
}
```