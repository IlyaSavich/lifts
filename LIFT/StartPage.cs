using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIFT.LiftSystem;
using LIFT;
using LIFT.LiftSystem.Events;
using System.Threading;
using System.Net.NetworkInformation;

namespace LIFT
{
    public partial class StartPage : MetroFramework.Forms.MetroForm
    {

        private int NumberofLifts;
        private int NumberOfFloors;
        private int CurrentFloor = 2;
        private int NecessaryFloor = 1;
        private int PassengerWeight = 80;
        private bool IsPressedButton = false;
        protected LiftSystem.LiftSystem liftSystem;
        protected Event EventWrapper;
        private bool IsPaintPassenger = false;
        private int liftPaint;
        private int floorPaint;
        private int _point;



        public StartPage()
        {
            InitializeComponent();
            StartButton.Enabled = false;
            StopButtoon.Enabled = false;
            CreatePersonButton.Enabled = false;
            MsWord.Enabled = false;
            toScreen.Enabled = false;
            MSExelButton.Enabled = false;
            SavePerson.Enabled = false;
            EventWrapper = Event.GetInstance();
            SetEvents();
        }

        protected void SetEvents()
        {
            EventWrapper.LiftOnFloorStop += EventLiftOnFloorStop;
        }


        private bool IsPaint = false;
        Bitmap door = new Bitmap(Properties.Resources.LiftDoors_1);
        protected void EventLiftOnFloorStop(int liftId, int floor)
        {

             
            Console.WriteLine("ON FLOOR STOP " + liftId);
            IsPaint = true;
            liftPaint = liftId;
            floorPaint = floor;
            

        }

        private void PaintLiftDoorOpen(Graphics g)
        {
            if (IsPaint)
            {
                g.DrawImage(Properties.Resources.LiftDoors_1, 45 + liftPaint * 70, 505 - (floorPaint -1)* 55, 30, 40);
                Thread.Sleep(100);
                g.DrawImage(Properties.Resources.LiftDoors_2, 45 + liftPaint * 70, 505 - (floorPaint - 1) * 55, 30, 40);
                Thread.Sleep(100);
                g.DrawImage(Properties.Resources.LiftDoors_3, 45 + liftPaint * 70, 505 - (floorPaint - 1) * 55, 30, 40);
                Thread.Sleep(100);
                g.DrawImage(Properties.Resources.LiftDoors_4, 45 + liftPaint * 70, 505 - (floorPaint - 1) * 55, 30, 40);
                Thread.Sleep(100);
                g.DrawImage(Properties.Resources.LiftDoors_Open, 45 + liftPaint * 70, 505 - (floorPaint - 1) * 55, 30, 40);
                Thread.Sleep(100);
            }

        }
        private void PaintLiftDoorClose(Graphics g)
        {
            if (IsPaint)
            {
                g.DrawImage(Properties.Resources.LiftDoors_4, 45 + liftPaint * 70, 505 - (floorPaint-1 )* 55, 30, 40);
                Thread.Sleep(100);
                g.DrawImage(Properties.Resources.LiftDoors_3, 45 + liftPaint * 70, 505 - (floorPaint - 1) * 55, 30, 40);
                Thread.Sleep(100);
                g.DrawImage(Properties.Resources.LiftDoors_2, 45 + liftPaint * 70, 505 - (floorPaint - 1) * 55, 30, 40);
                Thread.Sleep(100);
                g.DrawImage(Properties.Resources.LiftDoors_1, 45 + liftPaint * 70, 505 - (floorPaint - 1) * 55, 30, 40);
                Thread.Sleep(100);
                g.DrawImage(Properties.Resources.LiftDoors_Closed, 45 + liftPaint * 70, 505 - (floorPaint - 1) * 55, 30, 40);
                Thread.Sleep(100);
            }

        }

        private void PaintFloor(Graphics g)
        {
            if(IsPressedButton)
            for (int i = 0; i < NumberOfFloors; i++)
                g.DrawImage(Properties.Resources.Floor, 12, 500 - i * 55, 734, 50);

                  
        }

        private void PaintLift(Graphics g)
        {
           if(IsPressedButton)
            for (int i = 0; i < NumberOfFloors; i++)
                for (int j = 0; j < NumberofLifts; j++)
                    g.DrawImage(Properties.Resources.LiftDoors, 45 + j * 70, 505 - i * 55, 30, 40);     
          
        }

        private void PaintWell(Graphics g)
        {
            if(IsPressedButton)
            for (int i = 0; i < NumberofLifts; i++)
                g.DrawImage(Properties.Resources.well, 30 + i * 70, -5, 60, 734);
           
        }

        private void PainOnForm(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PaintFloor(g);
            PaintWell(g);
            PaintLift(g);   
         
        }
        
     


        private void PaintonFormLift(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PaintLiftDoorOpen(g);
            Thread.Sleep(1000);
            PaintLiftDoorClose(g);
            PainPassenger(g);
          
            

        }

       

      

        Bitmap man = new Bitmap(Properties.Resources.TrollMan);
        private void PainPassenger(Graphics g)
        {
            int x = 10;
            if (IsPaintPassenger)
                for (int i = 0; i < 10; i++)
                {
                  
                    g.DrawImage(Properties.Resources.TrollMan, 80+x, 505, 30, 40);
                    Thread.Sleep(50);
                                 
                    
                    x +=10;
                    this.Invalidate();
                    
                }
            
            
            

        }
       

    






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
            if ((errorMessageNumFloor.Text == "") && (errorMessageLift.Text == ""))
            {
                StartButton.Enabled = true;
            }


        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StopButtoon.Enabled = true;
            CreatePersonButton.Enabled = true;
            MsWord.Enabled = true;
            MSExelButton.Enabled = true;
            toScreen.Enabled = true;
            IsPressedButton = true;
            SavePerson.Enabled = true;
            this.liftSystem = new LiftSystem.LiftSystem(this.NumberOfFloors, this.NumberofLifts);
            liftSystem.Start();

        }
        private void SavePerson_Click(object sender, EventArgs e)
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


            if (WeightButton.Text != "")
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



            if ((errorMessageWeight.Text == "") && (errorMessageCurrentFloor.Text =="") &&(errorMessageNecFloor.Text == ""))
            {
                SavePerson.Enabled = true;
            }

        }


        private void CreatePersonButton_Click(object sender, EventArgs e)
        {

          
              if ((errorMessageCurrentFloor.Text == "") && (errorMessageNecFloor.Text == "") && (errorMessageWeight.Text == ""))
              {
                 liftSystem.CreatePassenger(PassengerWeight,  CurrentFloor ,NecessaryFloor);
                  IsPaintPassenger = true;
                         }
        }
        
        private void StopButton(object sender, EventArgs e)
        {

            StopButtoon.Enabled = false;
            StartButton.Enabled = true;
            CreatePersonButton.Enabled = false;

        }





        #endregion checkInPutParam

       
    }
}
