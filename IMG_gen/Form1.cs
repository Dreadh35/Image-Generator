using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

namespace IMG_gen
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
            What the fuck did you just fucking say about me, you little bitch? I’ll have you know I declare all
            my variables at the top of my class in  my IDEs, and I’ve been involved in numerous indie dev teams, 
            and I have over 300 confirmed git pulls.
         
            I am trained in office warfare and I’m the top developer in the entire cubicle farm. You are nothing to me
            but just another target. I will kill -9 you with precision the likes of which has never been seen before on 
            this Earth, mark my fucking words.
        
            You think you can get away with saying that shit to me over the Internet? Think again, fucker. As we speak I 
            am contacting my secret network of trolls across the darkweb and your IP is being traced right now so you 
            better prepare for unsolicited dick pics, faggot. The storm that wipes out the pathetic little thing you call 
            your social media account. You’re fucking dead, kid. I can be anywhere, anytime, and I can kill you in over
            seven hundred ways, and that's just with my guy fawkes mask.
        
            Not only am I extensively trained in google-fu, but I have access to the entire backlog of Stack Overflow 
            questions and I will use it to its full extent to wipe your miserable data off the face of the internet, 
            you little shit. If only you could have known what unholy retribution your little “clever” comment was 
            about to bring down upon you, maybe you would have held your fucking tongue.
        
            But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit fury all over you and you will 
            drown in it. I am legion. I do not forgive, I do not forget.
        */

        public int lastRandom = 0;
        public int lastrandomRed = 0;
        public int lastrandomGreen = 0;
        public int lastrandomBlue = 0;
        public int lastpoint = 0;

        async private void button1_Click(object sender, EventArgs e) {
            this.jumRange.Enabled = false;
            this.generateButton.Enabled = false;
            await Task.Run(() => doGenerate());
            Console.WriteLine("Done generating");
            this.jumRange.Enabled = true;
            this.generateButton.Enabled = true;

        }

        private void doGenerate() {
            List<List<int>> coords = createCoordList();
            Bitmap img = new Bitmap(this.picOutput.Size.Width, this.picOutput.Size.Height);
            Graphics imgGraphics = Graphics.FromImage(img);
            Random rnd = new Random();
            if (this.noise.Checked) {
                foreach (List<int> currentCoords in coords) {
                    imgGraphics.FillRectangle(pickBrush(rnd,Int32.Parse(this.jumRange.Text)), currentCoords[0], currentCoords[1], 1, 1);
                }
            }
            else if (this.lines.Checked) {
                int index = 0;
                Pen drawPen = new Pen(Color.White, 2);
                lastpoint = rnd.Next(coords.Count);
                imgGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                while (index <= Int32.Parse(jumRange.Text)) {
                    if (this.randomColor.Checked) {
                        drawPen.Brush = pickBrush(rnd, 50);
                    }
                    drawLine(rnd, coords, drawPen, imgGraphics);
                    index++;
                }
            }
            else if (this.arcs.Checked) {
                int index = 0;
                Pen drawPen = new Pen(Color.White, 2);
                lastpoint = rnd.Next(coords.Count);
                imgGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                while (index <= Int32.Parse(jumRange.Text)) {
                    if (this.randomColor.Checked) {
                        drawPen.Brush = pickBrush(rnd, 50);
                    }
                    drawBezier(rnd, coords, imgGraphics, drawPen);
                    index++;
                }
            }
            else if (this.random.Checked) {
                int index = 0;
                Pen drawPen = new Pen(Color.White, 2);
                lastpoint = rnd.Next(coords.Count);
                imgGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                while (index <= Int32.Parse(jumRange.Text)) {
                    if (this.randomColor.Checked) {
                        drawPen.Brush = pickBrush(rnd, 50);
                    }
                    if (rnd.Next(0, 10) <= 5) {
                        drawBezier(rnd, coords, imgGraphics, drawPen);
                    }
                    else {
                        drawLine(rnd, coords, drawPen, imgGraphics);
                    }
                    index++;
                }
            }
            this.picOutput.Image = img;
        }

        private List<List<int>> createCoordList() {
            List<List<int>> result = new List<List<int>>();
            int x = 0;
            int y = 0;
            while(y <= this.picOutput.Size.Height) {
                x = 0;
                while(x <= this.picOutput.Size.Width) {
                    List<int> temp1 = new List<int>();
                    temp1.Add(x);
                    temp1.Add(y);
                    result.Add(temp1);
                    x += 1;
                    
                    
                }
                y += 1;
            }
            result.Shuffle();
            return result;
        }

        private SolidBrush pickBrush(Random rnd, int range = 20) {
            //PropertyInfo[] props = typeof(Brushes).GetProperties();

            #region //some very ugly code, do not look
            
            int minRed = 0;
            int maxRed = 255;
            int minGreen = 0;
            int maxGreen = 255;
            int minBlue = 0;
            int maxBlue = 255;
            if (lastrandomRed != 0) {
                minRed = lastrandomRed - range;
                maxRed = lastrandomRed + range;
                if (minRed < 0) {
                    minRed = 0;
                }
                if (maxRed > 255) {
                    maxRed = 255;
                }                
            }

            if (lastrandomGreen != 0) {
                minGreen = lastrandomGreen - range;
                maxGreen = lastrandomGreen + range;
                if (minGreen < 0) {
                    minGreen = 0;
                }
                if (maxGreen > 255) {
                    maxGreen = 255;
                }
            }

            if (lastrandomBlue != 0) {
                minBlue = lastrandomBlue - range;
                maxBlue = lastrandomBlue + range;
                if (minBlue < 0) {
                    minBlue = 0;
                }
                if (maxBlue > 255) {
                    maxBlue = 255;
                }
            }
            
            #endregion 
            int randomRed = rnd.Next(minRed, maxRed);
            int randomBlue = rnd.Next(minBlue, maxBlue);
            int randomGreen = rnd.Next(minGreen, maxGreen);
            Color pickedColor = Color.FromArgb(randomRed, randomGreen,randomBlue);
            SolidBrush color = new SolidBrush(pickedColor);
            //result = (Brush)props[random].GetValue(null, null);
            
            lastrandomRed = randomRed;
            lastrandomBlue = randomBlue;
            lastrandomGreen = randomGreen;

            return color;
        }
        


        private static String GetRandomHex(int length, Random rnd) {
            String res;
            byte[] buffer = new byte[length / 2];
            rnd.NextBytes(buffer);
            res = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());

            return res;
        }

        private void noise_CheckedChanged(object sender, EventArgs e) {
            if(this.noise.Checked) {
                this.Jumprange.Text = "Colordifference:";
                this.randomColor.Visible = false;
            }
        }

        private void lines_CheckedChanged(object sender, EventArgs e) {
            if(this.lines.Checked) {
                this.Jumprange.Text = "Jumppoints:";
                this.randomColor.Visible = true;
            }
        }

        private void arcs_CheckedChanged(object sender, EventArgs e) {
            if (this.arcs.Checked) {
                this.Jumprange.Text = "Jumppoints:";
                this.randomColor.Visible = true;
            }
        }

        private void drawBezier(Random rnd, List<List<int>> coords, Graphics imgGraphics, Pen drawPen) {
            int point1 = lastpoint;
            int point2 = rnd.Next(coords.Count);
            int point3 = rnd.Next(coords.Count);
            int point4 = rnd.Next(coords.Count);
            imgGraphics.DrawBezier(drawPen, coords[point1][0], coords[point1][1], coords[point2][0], coords[point2][1], coords[point3][0], coords[point3][1], coords[point4][0], coords[point4][1]);
            
            lastpoint = point4;
        }

        private void drawLine(Random rnd, List<List<int>> coords, Pen drawPen, Graphics imgGraphics) {
            int point1 = lastpoint;
            int point2 = rnd.Next(coords.Count);
            imgGraphics.DrawLine(drawPen, coords[point1][0], coords[point1][1], coords[point2][0], coords[point2][1]);
            lastpoint = point2;
        }

        private void random_CheckedChanged(object sender, EventArgs e) {
            if (this.random.Checked) {
                this.Jumprange.Text = "Jumppoints:";
                this.randomColor.Visible = true;
            }
        }

        private void saveImage_Click(object sender, EventArgs e) {
            DialogResult DialogOut = this.saveImageDialog.ShowDialog();
            if(DialogOut == DialogResult.OK) {
                String filename = saveImageDialog.FileName;
                Console.WriteLine(filename);
                ImageFormat format;
                if (filename.Split('.')[1] == "png") {
                    format = ImageFormat.Png;
                }else if(filename.Split('.')[1] == "jpg") {
                    format = ImageFormat.Jpeg;
                } else {
                    format = ImageFormat.Jpeg;
                }
                this.picOutput.Image.Save(filename, format);
            }

        }

        private void clipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(picOutput.Image);
        }
    }



    static class extensions {
        public static void Shuffle<T>(this IList<T> list) {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1) {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static Stream ToStream(this Image image, ImageFormat format) {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }
    }
}
