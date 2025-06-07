namespace SudokuSolver
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        //empty puzzle for intiial load
        private readonly int[,] samplePuzzle = new int[9, 9]
        {
            {6, 7, 0, 0, 4, 8, 0, 0, 0},
            {5, 0, 0, 0, 3, 1, 0, 0, 0},
            {0, 3, 1, 0, 7, 0, 0, 0, 0},

            {1, 5, 0, 0, 2, 3, 4, 0, 6},
            {0, 0, 4, 1, 0, 0, 7, 5, 3},
            {3, 9, 6, 0, 0, 4, 0, 0, 8},

            {4, 0, 5, 0, 8, 7, 0, 0, 2},
            {0, 0, 0, 0, 0, 0, 1, 0, 0},
            {9, 2, 8, 5, 1, 0, 0, 7, 0}
        };

        //array that holds user input values
        private bool[,] isUserInput = new bool[9, 9];

        //load the sample puzzle into the grid
        private void LoadPuzzle(int[,] puzzle)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    string name = $"txt{row}{col}";
                    var ctrl = Controls.Find(name, true).FirstOrDefault() as TextBox;   //find the textbox[i][j]
                    if (ctrl != null)
                    {
                        ctrl.Text = puzzle[row, col] == 0 ? "" : puzzle[row, col].ToString();   //if 0 leave empty
                        ctrl.ForeColor = Color.Black;
                        ctrl.BackColor = Color.White;
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);  //upon initialization, load the form
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tlpMain.ColumnCount = 3;
            tlpMain.RowCount = 3;
            tlpMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;   //set the cell border style

            tlpMain.ColumnStyles.Clear();   //clear existing styles since I will be adding equal sized ones
            tlpMain.RowStyles.Clear();

            for (int i = 0; i < 3; i++) //add 3 columns and rows, taking up 33.33% of the width and height
            {
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }

            for (int outerRow = 0; outerRow < 3; outerRow++)
            {
                for (int outerCol = 0; outerCol < 3; outerCol++)
                {
                    var innerPanel = new TableLayoutPanel   //create a new inner panel for each 3x3 box
                    {
                        ColumnCount = 3,
                        RowCount = 3,
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
                    };

                    for (int i = 0; i < 3; i++) //same thing as above
                    {
                        innerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                        innerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
                    }

                    //this wil create 9 textboxes. So in total its a quadruple nested loop time complexity n^4 LOL
                    for (int innerRow = 0; innerRow < 3; innerRow++)
                    {
                        for (int innerCol = 0; innerCol < 3; innerCol++)
                        {
                            int globalRow = outerRow * 3 + innerRow;
                            int globalCol = outerCol * 3 + innerCol;

                            var txt = new TextBox
                            {
                                Name = $"txt{globalRow}{globalCol}",
                                Dock = DockStyle.Fill,
                                MaxLength = 1,
                                TextAlign = HorizontalAlignment.Center,
                                Font = new Font("Segoe UI", 16F, FontStyle.Bold)
                            };

                            innerPanel.Controls.Add(txt, innerCol, innerRow);
                        }
                    }

                    tlpMain.Controls.Add(innerPanel, outerCol, outerRow);
                }
            }

            LoadPuzzle(samplePuzzle);   //load the sample puzzle into the grid

        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            int[,] puzzle = ReadGrid();       //first off, get the current grid values as a 2D array    
            int[,] solved = new int[9, 9];

            NativeSudoku.solveSudoku(puzzle, solved);  //use the solveSudoku function from the native sudoku class

            WriteGrid(solved);       //finally, write the solved grid back to the textboxes            
        }



        private int[,] ReadGrid()
        {
            int[,] puzzle = new int[9, 9];

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    string name = $"txt{row}{col}";
                    var ctrl = Controls.Find(name, true).FirstOrDefault() as TextBox;

                    if (ctrl != null && int.TryParse(ctrl.Text, out int val) && val >= 1 && val <= 9)
                    {
                        puzzle[row, col] = val;
                        isUserInput[row, col] = true;
                    }
                    else
                    {
                        puzzle[row, col] = 0;
                        isUserInput[row, col] = false;
                    }
                }
            }

            return puzzle;
        }


        private void WriteGrid(int[,] solved)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    string name = $"txt{row}{col}";
                    var ctrl = Controls.Find(name, true).FirstOrDefault() as TextBox;

                    if (ctrl != null)
                    {
                        ctrl.Text = solved[row, col] == 0 ? "" : solved[row, col].ToString();

                        if (!isUserInput[row, col] && solved[row, col] != 0)
                        {
                            // Solver-generated
                            ctrl.ReadOnly = true;
                            ctrl.ForeColor = Color.DarkBlue;
                            ctrl.BackColor = Color.FromArgb(220, 230, 250); // soft blue
                            ctrl.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                        }
                        else
                        {
                            // User-entered or empty
                            ctrl.ForeColor = Color.Black;
                            ctrl.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] empty = new int[9, 9]
            {
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},

            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},

            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            for (int i = 0; i < 9; i++) { 
                for(int j = 0; j < 9; j++) {
                    isUserInput[i, j] = false; //reset user input tracking
                }
            }

            LoadPuzzle(empty); //load the empty grid
        }
    }

}
