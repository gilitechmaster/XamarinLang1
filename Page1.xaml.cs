using App18.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace App18
{
    //Page1은 문서 입력 화면
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename)) //문자열이 널인지 공백인지 확인한다.
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();
        }//저장버튼 누르면

        async void OnCalc1ButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }

            else
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                StreamWriter sw = new StreamWriter(filename, true);
                string[] arr = note.Text.Split(new string[]{

                "",

                        }, StringSplitOptions.None);


                foreach (string B in arr)
                {

                    if (B.Contains("\n")  // replace로 2차처리
                        )
                        sw.WriteLine("{0}", B
                          .Replace("\n", "")
                          );

                }

                sw.Close();

            }


            await Navigation.PopAsync();
        }
        //조합버튼 누르면
        //웹에서 문서를 수집하면, 어수선한 글이 많아서
        //조합을 먼저한 이후에 분해한다.

        async void OnCalc2ButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }

            else
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                StreamWriter sw = new StreamWriter(filename, true);
                string[] arr = note.Text.Split(new string[]{

                    ". ",//순차처리하므로 ". "를 앞에해두어야 한다.
                    ".",
                    "? ",
                    "?",
                    "! ",
                    "!"
                    

                        }, StringSplitOptions.None);
                int Key = 1;

                sw.WriteLine("====자연어처리==== \n");

                foreach (string B in arr)
                {
                    sw.WriteLine("\n"+ Key++ +") " + B);
                } // split로 1차처리
                sw.Close();

            }


            await Navigation.PopAsync();
        }//분해버튼 누르면

        

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Navigation.PopAsync();
        }//삭제버튼 누르면
    }
}






