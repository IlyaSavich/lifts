using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFT
{
    public partial class StartPage : MetroFramework.Forms.MetroForm
    {

        private int NumberofLifts;
        private int NumberOfFloors;
        private int CurrentFloor;
        private int NecessaryFloor;
        
        public StartPage()
        {
            InitializeComponent();
           
            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PaintBuilding(Graphics g)
        {
  //         g.DrawImage(Properties.Resources.Building, 12, 12, 734, 472);
        }

      /*  private void PaintElevators(Graphics g)
        {
            for (int i = 0; i < NumberofLifts; i++)
            {
                Lift ElevatorToPaint = MyBuilding.ArrayOfAllElevators[i];
                g.DrawImage(ElevatorToPaint.GetCurrentFrame(), ElevatorToPaint.GetElevatorXPosition(), ElevatorToPaint.GetElevatorYPosition(), 54, 90);
            }
        }

        private void PaintPassengers(Graphics g)
        {
            List<Passenger> CopyOfListOfAllPeopleWhoNeedAnimation = new List<Passenger>(MyBuilding.ListOfAllPeopleWhoNeedAnimation);

            foreach (Passenger PassengerToPaint in CopyOfListOfAllPeopleWhoNeedAnimation)
            {
                if ((PassengerToPaint != null) && (PassengerToPaint.GetPassengerVisibility()))
                {
                    g.DrawImage(PassengerToPaint.GetCurrentFrame(), PassengerToPaint.PassengerPosition.X, PassengerToPaint.PassengerPosition.Y + 15, 35, 75); // Y + 15, because passenger is 15 pixels lower than elevator
                }
            }
        }

    */

        private void timerWorkingTime_Tick(object sender, EventArgs e)
        {
            statusPanelWorkingTime.Text = DateTime.Now.ToString("HH:mm:ss"); // TODO show time from start system
        }             

        private void TextChangeNumFloor(object sender, EventArgs e)
        {

           
        }


        #region checkInputParam
        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            for (int i = 2; i <= 10; i++)
            {
                if (NumberOfFloorsButton.Text == i.ToString())
                {
                    this.NumberOfFloors = i;
                    errorMessageNumFloor.Text = "";
                    break;
                }
                else
                {
                    errorMessageNumFloor.Text = "Incorrect data";
                }
            }


            for (int i = 1; i <= 3; i++)
            {
                if (NumOfLifts.Text == i.ToString())
                {
                    this.NumberofLifts= i;
                    errorMessageLift.Text = "";
                    break;
                }
                else
                {
                    errorMessageLift.Text = "Incorrect data";
                }
            }

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            for (int i = 2; i <= 10; i++)
            {
                if (NumberOfFloorsButton.Text == i.ToString())
                {
                    this.NumberOfFloors = i;
                    errorMessageNumFloor.Text = "";
                    break;
                }
                else
                {
                    errorMessageNumFloor.Text = "Incorrect data";
                }
            }


            for (int i = 1; i <= 3; i++)
            {
                if (NumOfLifts.Text == i.ToString())
                {
                    this.NumberofLifts = i;
                    errorMessageLift.Text = "";
                    break;
                }
                else
                {
                    errorMessageLift.Text = "Incorrect data";
                }
            }
        }


        private void CreatePersonButton_Click(object sender, EventArgs e)
        {
            int i = 2;
            for (i = 2; i <= 10; i++)
            {
                if (CurrentFloorButton.Text == i.ToString())
                {
                    this.CurrentFloor = i;
                    errorMessageCurrentFloor.Text = "";
                    break;
                }
                else
                {
                    errorMessageCurrentFloor.Text = "Incorrect data";
                }
            }





            for (int j = 2; j <= 10; j++)
            {
                if (NecessaryFloorButton.Text == j.ToString() && i != j)
                {
                    this.NecessaryFloor = j;
                    errorMessageNecFloor.Text = "";
                    break;
                }
                else
                {
                    errorMessageNecFloor.Text = "Incorrect data";
                }
            }
            /* if (WeightButton.Text == i.ToString())
             {
                 this._CurrentFloor = i;
                 errorMessageCurrentFloor.Text = "";

             }*/




            #endregion checkInPutParam

        }
    }
}
