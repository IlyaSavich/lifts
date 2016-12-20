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

        private int NumberofLifts = 2;
        private int NumberOfFloors = 10;
        private int CurrentFloor;
        private int NecessaryFloor;
        private int PassengerWeight;
        
        public StartPage()
        {
            InitializeComponent();
           
            
        }


        private bool IsPressedButton = false;
        private void PaintFloor(Graphics g)
        {
            for (int i = 0; i< NumberOfFloors; i++)
         g.DrawImage(Properties.Resources.Floor, 12, 12+i*55, 734, 50);
        }

        private void PaintWell(Graphics g)
        {
            for (int i = 0; i < NumberofLifts; i++)
                g.DrawImage(Properties.Resources.well, 30+i*70, -5, 60, 734);
        }

        private void PainOnForm(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (IsPressedButton)
            {
                PaintFloor(g);
                PaintWell(g);
            }


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

      

        #region checkInputParam
        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (NumberOfFloorsButton.Text != "")
            {

                if (int.Parse(NumberOfFloorsButton.Text) >= 2 && int.Parse(NumberOfFloorsButton.Text) <= 10)
                {
                    this.NumberOfFloors = int.Parse(NumberOfFloorsButton.Text);
                    errorMessageNumFloor.Text = "";

                }
                else
                {
                    errorMessageNumFloor.Text = "Incorrect data";
                }
            }
            else
            {
                errorMessageNumFloor.Text = "Input data";
            }



            if (NumOfLifts.Text!="")
            {
                if (int.Parse(NumOfLifts.Text) >= 1 && int.Parse(NumOfLifts.Text) <= 3)
                {
                    this.NumberofLifts = int.Parse(NumOfLifts.Text);
                    errorMessageLift.Text = "";

                }
                else
                {
                    errorMessageLift.Text = "Incorrect data";
                }
            }
            else
            {
                errorMessageLift.Text = "Input data";
            }
            

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            IsPressedButton = true;
            Invalidate();
        }


        private void CreatePersonButton_Click(object sender, EventArgs e)
        {

            if (CurrentFloorButton.Text != "")
            {
                if (int.Parse(CurrentFloorButton.Text) <= NumberOfFloors && int.Parse(CurrentFloorButton.Text) >= 1)
                {
                    this.CurrentFloor = int.Parse(CurrentFloorButton.Text);
                    errorMessageCurrentFloor.Text = "";

                }
                else
                {
                    errorMessageCurrentFloor.Text = "Incorrect data";
                }
            }
            else
            {
                errorMessageCurrentFloor.Text = "Input data";
            }
            if (NecessaryFloorButton.Text != "")
            {
                if ((int.Parse(NecessaryFloorButton.Text) <= NumberOfFloors) && (int.Parse(NecessaryFloorButton.Text) >= 1) && (int.Parse(NecessaryFloorButton.Text) != int.Parse(CurrentFloorButton.Text)))
                {
                    this.CurrentFloor = int.Parse(NecessaryFloorButton.Text);
                    errorMessageNecFloor.Text = "";

                }
                else
                {
                    errorMessageNecFloor.Text = "Incorrect data";
                }
            }
            else
            {
                errorMessageNecFloor.Text = "Input data";
            }


            if (Weight.Text != "")
            {
                if ((int.Parse(WeightButton.Text) <= 400) && (int.Parse(WeightButton.Text) >= 30))
                {
                    this.PassengerWeight = int.Parse(WeightButton.Text);
                    errorMessageWeight.Text = "";

                }
                else
                {
                    errorMessageWeight.Text = "Incorrect data";
                }
            }
            else
            {
                errorMessageWeight.Text = "Input data";
            }
            











            #endregion checkInPutParam

        }

       
    }
}
