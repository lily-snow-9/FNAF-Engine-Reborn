﻿using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNAF_Engine_Reborn.Object_Editors
{
    internal class Menu_Editor
    {
        private readonly reborn reborn;

        public Menu_Editor(reborn reborn)
        {
            this.reborn = reborn;
        }
        public async Task Wait(int miliseconds)
        {
            await Task.Delay(miliseconds);
        }
        //public string Menu { get; set; }
        public void ShowActionEditor(string ID, string Menu)
        {
            //wtf old code
            //todo i guess
        }
        public void CreateText(string ID, string Menu)
        {
            _ = Directory.CreateDirectory(Menu + "/text_elements/" + ID);
            string NewPath = Menu + "/text_elements/" + ID;
            File.WriteAllText(NewPath + "/id.txt", ID);
            File.WriteAllText(NewPath + "/text.txt", "Text");
            File.WriteAllText(NewPath + "/font.txt", "Consolas");
            File.WriteAllText(NewPath + "/fontsize.txt", "12");
            File.WriteAllText(NewPath + "/args.txt", "false");
            File.WriteAllText(NewPath + "/x.txt", "0");
            File.WriteAllText(NewPath + "/y.txt", "0");
            File.WriteAllText(NewPath + "/functions.txt", "");
            File.WriteAllText(NewPath + "/functionshover.txt", "");
            File.WriteAllText(NewPath + "/functionsunhover.txt", "");
            File.WriteAllText(NewPath + "/functionshold.txt", "");
            File.WriteAllText(NewPath + "/color.txt", "255,255,255");
            File.WriteAllText(NewPath + "/style.txt", "0");
        }
        public void RewriteTextData(string Menu, TextElement TextElement)
        {
            string ID = TextElement.ID;
            string Path = Menu + "/text_elements/" + ID;
            File.WriteAllText(Path + "/text.txt", TextElement.Text);
            File.WriteAllText(Path + "/font.txt", TextElement.FontName);
            File.WriteAllText(Path + "/fontsize.txt", Convert.ToString(TextElement.FontSize));
            File.WriteAllText(Path + "/args.txt", Convert.ToString(TextElement.args));
            File.WriteAllText(Path + "/x.txt", Convert.ToString(TextElement.X));
            File.WriteAllText(Path + "/y.txt", Convert.ToString(TextElement.Y));
            File.WriteAllText(Path + "/functions.txt", TextElement.Functions);
            File.WriteAllText(Path + "/functionshover.txt", TextElement.FunctionsHover);
            File.WriteAllText(Path + "/functionsunhover.txt", TextElement.FunctionsUnhover);
            File.WriteAllText(Path + "/functionshold.txt", TextElement.FunctionsHold);
            File.WriteAllText(Path + "/color.txt", TextElement.Color.R.ToString() + "," + TextElement.Color.G.ToString() + "," + TextElement.Color.B.ToString());
            File.WriteAllText(Path + "/style.txt", TextElement.style.ToString());
        }
        public void AddText(string Menu, TextElement TextElement, string Project)
        {
            var Selected = false;
            Panel Preview = reborn.MenuPreview;
            if (TextElement.args == false)
            {
                var Text = new Control();
                if (TextElement.style == 0)
                {
                    Text = new Label
                    {
                        Location = new Point(TextElement.X, TextElement.Y), // set location
                        AutoSize = true, // the text's text size is the text size
                        BackColor = Color.Transparent,
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = TextElement.Color,
                        Font = new Font(TextElement.Font, FontStyle.Regular),
                        Text = TextElement.Text,
                        Name = TextElement.ID
                    }; //the menu editor text 
                }
                else
                {
                    Text = new Button
                    {
                        Location = new Point(TextElement.X, TextElement.Y), // set location
                        AutoSize = true, // the text's text size is the text size
                        BackColor = Color.Transparent,
                        ForeColor = TextElement.Color,
                        FlatStyle = FlatStyle.System,
                        Font = new Font(TextElement.Font, FontStyle.Regular),
                        Text = TextElement.Text,
                        Name = TextElement.ID
                    }; //the menu editor text 
                }
                Text.Draggable(true);


                Text.Click += newText_Select;
                Text.Leave += newText_Leave;
                Text.MouseLeave += newText_Move;
                Text.MouseDoubleClick += Text_MouseDoubleClick;
                Text.MouseHover += Text_MouseHover;


                reborn.Element_Text_MenuEditor.TextChanged += TextChanged;
                reborn.Element_FontSize_MenuEditor.TextChanged += FontSizeChanged;
                reborn.Element_Color_MenuEditor.TextChanged += ColorChanged;
                reborn.Element_Font_MenuEditor.TextChanged += FontChanged;

                reborn.BtnStyle.SelectedIndexChanged += BtnStyle_SelectedIndexChanged;

                //reborn.MenuEditor_CodeEditorClick.TextChanged += CodeClickChanged;
                //reborn.MenuEditor_CodeEditorHover.TextChanged += CodeHoverChanged;
                //reborn.MenuEditor_CodeEditorUnhover.TextChanged += CodeUnhoverChanged;
                //reborn.MenuEditor_CodeEditorHold.TextChanged += CodeHoldChanged;

                void Text_MouseHover(object sender, EventArgs e)
                {
                    //Text.BorderStyle = BorderStyle.FixedSingle;
                }
                void CodeClickChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (Selected == true)
                        {
                            if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                            {
                                //TextElement.Functions = reborn.MenuEditor_CodeEditorClick.Text;
                                RewriteTextData(Menu, TextElement);
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                async void CodeHoverChanged(object sender, EventArgs e)
                {
                    await Task.Delay(50);
                    try
                    {
                        if (Selected == true)
                        {
                            if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                            {
                                //TextElement.FunctionsHover = reborn.MenuEditor_CodeEditorHover.Text;
                                RewriteTextData(Menu, TextElement);
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                async void CodeUnhoverChanged(object sender, EventArgs e)
                {
                    //
                    await Task.Delay(50);
                    if (Selected == true)
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                        {
                            //TextElement.FunctionsUnhover = reborn.MenuEditor_CodeEditorUnhover.Text;
                            RewriteTextData(Menu, TextElement);
                        }
                    }
                }
                async void CodeHoldChanged(object sender, EventArgs e)
                {
                    await Task.Delay(50);
                    try
                    {
                        if (Selected == true)
                        {
                            if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                            {
                                //TextElement.FunctionsHold = reborn.MenuEditor_CodeEditorHold.Text;
                                RewriteTextData(Menu, TextElement);
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                async void FontChanged(object sender, EventArgs e)
                {
                    await Task.Delay(50);
                    if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                    {
                        try
                        {
                            TextElement.FontName = reborn.Element_Font_MenuEditor.Text;
                            RewriteTextData(Menu, TextElement);
                            Text.Font = new Font(reborn.Element_Font_MenuEditor.Text, Convert.ToSingle(reborn.Element_FontSize_MenuEditor.Text));
                        }
                        catch (Exception)
                        {
                            Text.Font = new Font("Microsoft Sans Serif", Text.Font.Size);
                        }
                    }
                }
                async void TextChanged(object sender, EventArgs e)
                {
                    await Task.Delay(1);
                    try
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                        {
                            TextElement.Text = reborn.Element_Text_MenuEditor.Text;
                            Text.Text = reborn.Element_Text_MenuEditor.Text;
                            RewriteTextData(Menu, TextElement);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                async void BtnStyle_SelectedIndexChanged(object sender, EventArgs e)
                {
                    await Task.Delay(1);
                    try
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                        {
                            TextElement.style = (byte)reborn.BtnStyle.SelectedIndex;
                            RewriteTextData(Menu, TextElement);
                            RefreshElements(Menu, Project);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                async void ColorChanged(object sender, EventArgs e)
                {
                    await Task.Delay(1);
                    try
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                        {
                            string[] RGB = reborn.Element_Color_MenuEditor.Text.Split(',');
                            if (RGB.Length == 3)
                            {
                                int R = Convert.ToInt32(RGB[0]);
                                int G = Convert.ToInt32(RGB[1]);
                                int B = Convert.ToInt32(RGB[2]);
                                TextElement.Color = Color.FromArgb(R, G, B);
                                RewriteTextData(Menu, TextElement);
                                Text.ForeColor = Color.FromArgb(R, G, B);
                            }
                            else
                            {

                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                async void FontSizeChanged(object sender, EventArgs e)
                {
                    await Task.Delay(1);
                    try
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Text.Name)
                        {
                            float fontsize = Convert.ToSingle(reborn.Element_FontSize_MenuEditor.Text);
                            TextElement.FontSize = fontsize;
                            RewriteTextData(Menu, TextElement);
                            Text.Font = new Font(reborn.Element_Font_MenuEditor.Text, Convert.ToSingle(reborn.Element_FontSize_MenuEditor.Text));
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                void newText_Select(object sender, EventArgs e)
                {
                    try
                    {
                        Selected = true;
                        reborn.Element_Font_MenuEditor.Text = TextElement.FontName;
                        reborn.Element_ID_MenuEditor.Text = Text.Name;
                        reborn.Element_X_MenuEditor.Text = "X: " + Text.Location.X;
                        reborn.Element_Y_MenuEditor.Text = "Y: " + Text.Location.Y;
                        reborn.Element_Text_MenuEditor.Text = TextElement.Text;
                        reborn.Element_FontSize_MenuEditor.Text = Convert.ToString(TextElement.FontSize);
                        reborn.Element_Color_MenuEditor.Text = TextElement.Color.R.ToString() + "," + TextElement.Color.G.ToString() + "," + TextElement.Color.B.ToString();
                        //reborn.MenuEditor_CodeEditorClick.Text = TextElement.Functions;
                        //reborn.MenuEditor_CodeEditorHover.Text = TextElement.FunctionsHover;
                        //reborn.MenuEditor_CodeEditorUnhover.Text = TextElement.FunctionsUnhover;
                        //reborn.MenuEditor_CodeEditorHold.Text = TextElement.FunctionsHold;
                    }
                    catch (Exception)
                    {

                    }
                }
                void newText_Leave(object sender, EventArgs e)
                {
                    try
                    {
                        Selected = false;
                        //Text.BorderStyle = BorderStyle.None;
                    }
                    catch (Exception)
                    {

                    }
                }
                void newText_Move(object sender, EventArgs e)
                {
                    try
                    {
                        //Text.BorderStyle = BorderStyle.None;
                        TextElement.X = Text.Location.X;
                        TextElement.Y = Text.Location.Y;
                        RewriteTextData(Menu, TextElement);
                        reborn.Element_X_MenuEditor.Text = "X: " + Text.Location.X;
                        reborn.Element_Y_MenuEditor.Text = "Y: " + Text.Location.Y;
                    }
                    catch (Exception)
                    {

                    }
                }
                void Text_MouseDoubleClick(object sender, MouseEventArgs e)
                {
                    try
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            TextElement.args = true;
                            RewriteTextData(Menu, TextElement);
                            RefreshElements(Menu, Project);
                            reborn.menuEditorPanel.Hide();
                            reborn.menuEditorPanel.Show();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                Preview.Controls.Add(Text);
            }
            else
            {

            }
        }
        //IMAGES

        public void CreateImage(string ID, string Menu, string FullImagePath, string Project)
        {
            _ = Directory.CreateDirectory(Menu + "/image_elements/" + ID);
            string NewPath = Menu + "/image_elements/" + ID;
            Import_Files.CreateSprite(FullImagePath, ID, Project);
            File.WriteAllText(NewPath + "/id.txt", ID);
            File.WriteAllText(NewPath + "/args.txt", "false");
            File.WriteAllText(NewPath + "/x.txt", "0");
            File.WriteAllText(NewPath + "/y.txt", "0");
            File.WriteAllText(NewPath + "/functions.txt", "");
            File.WriteAllText(NewPath + "/functionshover.txt", "");
            File.WriteAllText(NewPath + "/functionsunhover.txt", "");
            File.WriteAllText(NewPath + "/functionshold.txt", "");
        }
        public void RewriteImageData(string Menu, ImageElement ImageElement)
        {
            string ID = ImageElement.ID;
            string Path = Menu + "/image_elements/" + ID;
            File.WriteAllText(Path + "/args.txt", Convert.ToString(ImageElement.args));
            File.WriteAllText(Path + "/x.txt", Convert.ToString(ImageElement.X));
            File.WriteAllText(Path + "/y.txt", Convert.ToString(ImageElement.Y));
            File.WriteAllText(Path + "/functions.txt", ImageElement.Functions);
            File.WriteAllText(Path + "/functionshover.txt", ImageElement.FunctionsHover);
            File.WriteAllText(Path + "/functionsunhover.txt", ImageElement.FunctionsUnhover);
            File.WriteAllText(Path + "/functionshold.txt", ImageElement.FunctionsHold);
        }
        public void AddImage(string Menu, ImageElement ImageElement, string Project)
        {
            Panel Preview = reborn.MenuPreview;
            if (ImageElement.args == false)
            {
                var width = 0;
                var height = 0;

                width = System.Drawing.Image.FromFile(Project + "/images/" + ImageElement.ID).Size.Width / 2;
                height = System.Drawing.Image.FromFile(Project + "/images/" + ImageElement.ID).Size.Width / 2;

                Size imgSize = new Size(width, height);
                PictureBox Image = new PictureBox
                {
                    Location = new Point(ImageElement.X, ImageElement.Y), // set location
                    BackColor = Color.Transparent,
                    Size = imgSize,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackgroundImage = System.Drawing.Image.FromFile(Project + "/images/" + ImageElement.ID),
                    Name = ImageElement.ID
                }; //the menu editor image 
                Image.Draggable(true);
                Image.MouseLeave += Image_MouseLeave;
                Image.Click += newImage_Select;
                Image.Move += newImage_Move;
                Image.MouseDoubleClick += Image_MouseDoubleClick;
                //reborn.MenuEditor_CodeEditorClick.TextChanged += CodeClickChanged;
                //reborn.MenuEditor_CodeEditorHover.TextChanged += CodeHoverChanged;
                //reborn.MenuEditor_CodeEditorUnhover.TextChanged += CodeUnhoverChanged;
                //reborn.MenuEditor_CodeEditorHold.TextChanged += CodeHoldChanged;
                Preview.Controls.Add(Image);
                void CodeClickChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Image.Name)
                        {
                            //ImageElement.Functions = reborn.MenuEditor_CodeEditorClick.Text;
                            RewriteImageData(Menu, ImageElement);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                void CodeHoverChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Image.Name)
                        {
                            //ImageElement.FunctionsHover = reborn.MenuEditor_CodeEditorHover.Text;
                            RewriteImageData(Menu, ImageElement);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                void CodeUnhoverChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Image.Name)
                        {
                            //ImageElement.FunctionsUnhover = reborn.MenuEditor_CodeEditorUnhover.Text;
                            RewriteImageData(Menu, ImageElement);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                void CodeHoldChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (reborn.Element_ID_MenuEditor.Text == Image.Name)
                        {
                            //ImageElement.FunctionsHold = reborn.MenuEditor_CodeEditorHold.Text;
                            RewriteImageData(Menu, ImageElement);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                void newImage_Select(object sender, EventArgs e)
                {
                    try
                    {
                        Image.BorderStyle = BorderStyle.FixedSingle;
                        reborn.Element_ID_MenuEditor.Text = Image.Name;
                        reborn.Element_X_MenuEditor.Text = "X: " + Image.Location.X;
                        reborn.Element_Y_MenuEditor.Text = "Y: " + Image.Location.Y;
                        //reborn.MenuEditor_CodeEditorClick.Text = ImageElement.Functions;
                        //reborn.MenuEditor_CodeEditorHover.Text = ImageElement.FunctionsHover;
                        //reborn.MenuEditor_CodeEditorUnhover.Text = ImageElement.FunctionsUnhover;
                        //reborn.MenuEditor_CodeEditorHold.Text = ImageElement.FunctionsHold;
                    }
                    catch (Exception)
                    {

                    }
                }
                void newImage_Move(object sender, EventArgs e)
                {
                    try
                    {
                        ImageElement.X = Image.Location.X;
                        ImageElement.Y = Image.Location.Y;
                        RewriteImageData(Menu, ImageElement);
                        reborn.Element_X_MenuEditor.Text = "X: " + Image.Location.X;
                        reborn.Element_Y_MenuEditor.Text = "Y: " + Image.Location.Y;
                    }
                    catch (Exception)
                    {

                    }
                }
                void Image_MouseDoubleClick(object sender, MouseEventArgs e)
                {
                    try
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            ImageElement.args = true;
                            RewriteImageData(Menu, ImageElement);
                            RefreshElements(Menu, Project);
                            reborn.menuEditorPanel.Hide();
                            reborn.menuEditorPanel.Show();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                void Image_MouseLeave(object sender, EventArgs e)
                {
                    Image.BorderStyle = BorderStyle.None;
                }
            }
            else
            {

            }
        }
        public void RefreshElements(string Menu, string Project)
        {
            reborn.MenuPreview.Controls.Clear();
            string[] TextElements = Directory.GetDirectories(Menu + "/text_elements");
            foreach (string TextElement in TextElements)
            {
                string id = File.ReadAllText(TextElement + "/id.txt");
                string text = File.ReadAllText(TextElement + "/text.txt");
                string args = File.ReadAllText(TextElement + "/args.txt");
                string functions = File.ReadAllText(TextElement + "/Functions.txt");
                string functionshold = File.ReadAllText(TextElement + "/Functionshold.txt");
                string functionshover = File.ReadAllText(TextElement + "/Functionshover.txt");
                string functionsunhover = File.ReadAllText(TextElement + "/Functionsunhover.txt");
                string fontname = File.ReadAllText(TextElement + "/font.txt");
                string fontsize_string = File.ReadAllText(TextElement + "/fontsize.txt");
                int x = Convert.ToInt32(File.ReadAllText(TextElement + "/x.txt"));
                int y = Convert.ToInt32(File.ReadAllText(TextElement + "/y.txt"));
                string colorTxt = File.ReadAllText(TextElement + "/color.txt");
                string[] SeparatedRGB = colorTxt.Split(',');
                int R = Convert.ToInt32(SeparatedRGB[0]);
                int G = Convert.ToInt32(SeparatedRGB[1]);
                int B = Convert.ToInt32(SeparatedRGB[2]);
                int fontsize = Convert.ToInt32(fontsize_string);
                string style = File.ReadAllText(TextElement + "/style.txt");

                FontFamily fontfamily;

                try
                {
                    fontfamily = new FontFamily(fontname);
                }
                catch (Exception)
                {
                    fontfamily = new FontFamily("Consolas");
                }

                Font font = new Font(fontfamily, fontsize);

                TextElement NewText = new TextElement
                {
                    ID = id,
                    Text = text,
                    FontSize = fontsize,
                    Font = font,
                    FontName = fontname,
                    Functions = functions,
                    FunctionsHold = functionshold,
                    FunctionsHover = functionshover,
                    FunctionsUnhover = functionsunhover,
                    X = x,
                    Y = y,
                    args = Convert.ToBoolean(args),
                    Color = Color.FromArgb(R, G, B),
                    style = Convert.ToByte(style)
                };
                AddText(Menu, NewText, Project);
            }
            string[] ImageElements = Directory.GetDirectories(Menu + "/image_elements");
            foreach (string ImageElement in ImageElements)
            {
                string id = File.ReadAllText(ImageElement + "/id.txt");
                string args = File.ReadAllText(ImageElement + "/args.txt");
                string functions = File.ReadAllText(ImageElement + "/Functions.txt");
                string functionshold = File.ReadAllText(ImageElement + "/Functionshold.txt");
                string functionshover = File.ReadAllText(ImageElement + "/Functionshover.txt");
                string functionsunhover = File.ReadAllText(ImageElement + "/Functionsunhover.txt");
                int x = Convert.ToInt32(File.ReadAllText(ImageElement + "/x.txt"));
                int y = Convert.ToInt32(File.ReadAllText(ImageElement + "/y.txt"));

                ImageElement NewImage = new ImageElement
                {
                    ID = id,
                    Functions = functions,
                    FunctionsHold = functionshold,
                    FunctionsHover = functionshover,
                    FunctionsUnhover = functionsunhover,
                    X = x,
                    Y = y,
                    args = Convert.ToBoolean(args)
                };
                AddImage(Menu, NewImage, Project);
            }
        }
    }
}
