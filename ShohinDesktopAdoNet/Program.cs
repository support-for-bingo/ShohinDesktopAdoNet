namespace ShohinDesktopAdoNet
{
    internal static class Program
    {
        /// <summary>�A�v���P�[�V�����̃��C���G���g���|�C���g</summary>
        [STAThread]
        static void Main()
        {
            //�W���O�n���h���[�쐬�E�N��
            OriginalUncaughtException.Ini();

            // ��DPI�ݒ��f�t�H���g�t�H���g�̐ݒ�ȂǁA�A�v���P�[�V�����\�����J�X�^�}�C�Y����ɂ́A
            // https://aka.ms/applicationconfiguration���Q�Ƃ��Ă�������
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1Control());
        }
    }

    /// <summary>�L���b�`����Ȃ�������O���L���b�`����W���O�N���X</summary>
    public class OriginalUncaughtException : LastException
    {
        public static void Ini()
        {
            //Windows�t�H�[���A�v���P�[�V�����p�W���O�n���h���[�̒�`
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        }

        //�W���O�C�x���g�v���V�[�W���[
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //��O�̓��e��g���[�X���e��Log�ɏo�͂������ꍇ�⃆�[�U�[�ɉ�ʏo�͂������ꍇ�ɂ����֏����܂��B
            _LastExcepTitle = e.Exception.GetType().ToString();
            _LastExcepPlace = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            _LastExcepParam = "";
            _LastExcepMessage = e.Exception.Message;
            _LastExcepTrace = e.Exception.StackTrace;

            //while((_LastExcepTitle.IndexOf(".") > 0) == true) //.�������Ȃ�܂ŌJ��Ԃ�
            //{
            //    _LastExcepTitle = _LastExcepTitle.Substring(_LastExcepTitle.IndexOf(".")); //.�ȍ~�����o��
            //    _LastExcepTitle = _LastExcepTitle.TrimStart('.'); //�擪��.���폜
            //}

            //��O���O��������
            //LogWrite();

            if (_LastExcepTitle == "ShohinDddSampleCsharp.Models.DomainObjects.DomainObjectException")
            {

                MessageBox.Show($"���͂����l�͐���������܂���ł����B{Environment.NewLine}{_LastExcepMessage}", "�薼", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //���b�Z�[�W�_�C�A���O
                MessageBox.Show("�A�v���P�[�V�����G���[���N���܂����B�A�v���P�[�V�������I�����܂��B" + Environment.NewLine +
                    "���b�Z�[�W�F" + e.Exception.GetType().ToString() + Environment.NewLine + "�X�^�b�N�g���[�X�F" + e.Exception.StackTrace);

                //�A�v���P�[�V�����̏I��
                Application.Exit();
            }
        }
    }
}