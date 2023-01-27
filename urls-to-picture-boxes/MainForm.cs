namespace urls_to_picture_boxes
{
    public partial class MainForm : Form
    {
        public MainForm() =>InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            int id = 0;
            // Here we have "already read" the URLs from the local store.
            foreach (var url in new string[] 
            {
                "https://i.stack.imgur.com/eSiWr.png",
                "https://i.stack.imgur.com/o5dmA.png",
                "https://i.stack.imgur.com/aqAuN.png",
            })
            {
                var dynamicPB = new PictureBox
                {
                    Width = 
                        flowLayoutPanel.Width 
                        - SystemInformation.VerticalScrollBarWidth,
                    Height = 200,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Azure,
                    // In this case, the url is already stored here...
                    ImageLocation = url,
                    // ...but here are a couple of other options.
                    Name = $"pictureBox{++id}",
                    Tag = $"Tag Identifier {id}",
                    Padding = new Padding(10),
                };
                dynamicPB.Click += onAnyPictureBoxClick;
                flowLayoutPanel.Controls.Add(dynamicPB);
            }
        }

        private void onAnyPictureBoxClick(object? sender, EventArgs e)
        {
            if(sender is PictureBox pictureBox)
            {
                var builder = new List<string>();
                builder.Add($"Name: {pictureBox.Name}");
                builder.Add($"Tag: {pictureBox.Tag}");
                builder.Add($"Image Location: {pictureBox.ImageLocation}");
                MessageBox.Show(string.Join(Environment.NewLine, builder));
            }
        }
    }
}