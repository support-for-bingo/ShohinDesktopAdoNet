namespace ShohinDesktopAdoNet
{
    internal static class Program
    {
        /// <summary>アプリケーションのメインエントリポイント</summary>
        [STAThread]
        static void Main()
        {
            //集約例外ハンドラー作成・起動
            OriginalUncaughtException.Ini();

            // 高DPI設定やデフォルトフォントの設定など、アプリケーション構成をカスタマイズするには、
            // https://aka.ms/applicationconfigurationを参照してください
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1Control());
        }
    }

    /// <summary>キャッチされなかった例外をキャッチする集約例外クラス</summary>
    public class OriginalUncaughtException : LastException
    {
        public static void Ini()
        {
            //Windowsフォームアプリケーション用集約例外ハンドラーの定義
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        }

        //集約例外イベントプロシージャー
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //例外の内容やトレース内容をLogに出力したい場合やユーザーに画面出力したい場合にここへ書きます。
            _LastExcepTitle = e.Exception.GetType().ToString();
            _LastExcepPlace = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            _LastExcepParam = "";
            _LastExcepMessage = e.Exception.Message;
            _LastExcepTrace = e.Exception.StackTrace;

            //while((_LastExcepTitle.IndexOf(".") > 0) == true) //.が無くなるまで繰り返し
            //{
            //    _LastExcepTitle = _LastExcepTitle.Substring(_LastExcepTitle.IndexOf(".")); //.以降を取り出し
            //    _LastExcepTitle = _LastExcepTitle.TrimStart('.'); //先頭の.を削除
            //}

            //例外ログ書き込み
            //LogWrite();

            if (_LastExcepTitle == "ShohinDddSampleCsharp.Models.DomainObjects.DomainObjectException")
            {

                MessageBox.Show($"入力した値は正しくありませんでした。{Environment.NewLine}{_LastExcepMessage}", "題名", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //メッセージダイアログ
                MessageBox.Show("アプリケーションエラーが起きました。アプリケーションを終了します。" + Environment.NewLine +
                    "メッセージ：" + e.Exception.GetType().ToString() + Environment.NewLine + "スタックトレース：" + e.Exception.StackTrace);

                //アプリケーションの終了
                Application.Exit();
            }
        }
    }
}