using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;

namespace Triqui.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button button1, button2, button3, button4, button5, button6, button7, button8, button9, resetGame;
        TextView winnerTextview;
        int Count = 0;
        int[,] values = new int[3, 3];
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button6 = FindViewById<Button>(Resource.Id.button6);
            button7 = FindViewById<Button>(Resource.Id.button7);
            button8 = FindViewById<Button>(Resource.Id.button8);
            button9 = FindViewById<Button>(Resource.Id.button9);
            winnerTextview = FindViewById<TextView>(Resource.Id.winnerTextview);
            resetGame = FindViewById<Button>(Resource.Id.resetGame);
            resetGame.Click += ResetGame_Click;  
            ////button1.Click += Button1_Click;
            //button2.Click += Button2_Click;
            //button3.Click += Button3_Click;
            //button4.Click += Button4_Click;
            //button5.Click += Button5_Click;
            //button6.Click += Button6_Click;
            //button7.Click += Button7_Click;
            //button8.Click += Button8_Click;
            //button9.Click += Button9_Click;
            ResetGame();
        }

        private void ResetGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            Count = 0;
            values = new int[3, 3];
            winnerTextview.Visibility = ViewStates.Invisible;
            resetGame.Visibility = ViewStates.Invisible;
            button1.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button2.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button3.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button4.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button5.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button6.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button7.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button8.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button9.SetBackgroundResource(global::Android.Resource.Drawable.ButtonDefault);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        private void DisableButtons()
        {
            
            resetGame.Visibility = ViewStates.Visible;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        private void playerWin(int player)
        {
            winnerTextview.Text = $"Player {player} won";
            winnerTextview.Visibility = ViewStates.Visible;
            DisableButtons();
        }

        private bool checkWinner(int value)
        {
            if (checkRows(value)) return true;
            if (checkColumns(value)) return true;
            if (checkCross(value)) return true;
            return false;
        }

        private bool checkRows(int value)
        {
            for (int i = 0; i <= 2; i++)
            {
                var _count = 0;
                for (int j = 0; j <= 2; j++)
                {
                    if (values[i, j] == value)
                    {
                        _count++;
                    }
                    if (_count == 3) return true;
                }
            }
            return false;
        }

        private bool checkColumns(int value)
        {
            for (int i = 0; i <= 2; i++)
            {
                var _count = 0;
                for (int j = 0; j <= 2; j++)
                {
                    if (values[j, i] == value)
                    {
                        _count++;
                    }
                    if (_count == 3) return true;
                }
            }
            return false;
        }

        private bool checkCross(int value)
        {
            var _count = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (values[i, i] == value)
                {
                    _count++;
                }
                if (_count == 3) return true;
            }

            _count = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (values[i, 2-i] == value)
                {
                    _count++;
                }
                if (_count == 3) return true;
            }

            return false;
        }

        [Java.Interop.Export("ButtonClicked")]
        public void ButtonClicked(View v) //CALLBACK FUNCTION
        {
            int value;
            Count++;
            v.Enabled = false;
            if (Count % 2 != 0)
            {
                v.SetBackgroundResource(Resource.Drawable.ic_circle);
                value = 1;
            }
            else
            {
                v.SetBackgroundResource(Resource.Drawable.ic_cross);
                value = 2;
            }
            
            switch (v.Id)
            {
                case Resource.Id.button1:
                    values[0, 0] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                case Resource.Id.button2:
                    values[0, 1] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                case Resource.Id.button3:
                    values[0, 2] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                case Resource.Id.button4:
                    values[1, 0] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                case Resource.Id.button5:
                    values[1, 1] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                case Resource.Id.button6:
                    values[1, 2] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                case Resource.Id.button7:
                    values[2, 0] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                case Resource.Id.button8:
                    values[2, 1] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                case Resource.Id.button9:
                    values[2, 2] = value;
                    if (checkWinner(value)) playerWin(value);
                    break;
                default:
                    break;
            }

            if (Count == 9)
            {
                resetGame.Visibility = ViewStates.Visible;
            }
        }


        private void Button9_Click(object sender, System.EventArgs e)
        {
            Count++;
            if (Count % 2 != 0)
            {
                button9.SetBackgroundResource(Resource.Drawable.ic_circle);
            }
            else
            {
                button9.SetBackgroundResource(Resource.Drawable.ic_cross);
            }
            button9.Enabled = false;
        }

        private void Button8_Click(object sender, System.EventArgs e)
        {
            Count++;
        }

        private void Button7_Click(object sender, System.EventArgs e)
        {
            Count++;
        }

        private void Button6_Click(object sender, System.EventArgs e)
        {
            Count++;
        }

        private void Button5_Click(object sender, System.EventArgs e)
        {
            Count++;
        }

        private void Button4_Click(object sender, System.EventArgs e)
        {
            Count++;
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            Count++;
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            Count++;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Count++;
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] global::Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}