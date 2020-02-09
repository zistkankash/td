using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Psychophysics.Designer;

namespace Basics
{
	public class FrameProperties
	{
		public Color BGColor;
		public int FrameTime;
		
		public List<ObjectProp> Fixation = new List<ObjectProp>();
		
		public int NumberSaccade;
		
		public FixationPts[] Stimulus;
		public Color[] StimulusColor;
		public int RewardType;

		public HintForm Cue;
		public ShowFr[] ShowFrame;
		public TriggerEvents events;
		public RepeatLinkFrame RepeatInfo;

		public FrameProperties()
		{
			BGColor = Color.Black;
			FrameTime = 0;
						
			NumberSaccade = 1;
			Stimulus = new FixationPts[NumberSaccade];
			Stimulus[0] = new FixationPts();
			Stimulus[0].Width = 0;
			Stimulus[0].Xloc = 0;
			Stimulus[0].Yloc = 0;
			RewardType = 0;

			Cue = new HintForm();
			ShowFrame = new ShowFr[1];
			events = new TriggerEvents();
			RepeatInfo = new RepeatLinkFrame();
		}

		public FrameProperties Copy()
		{
			FrameProperties fr = new FrameProperties();
			fr.SetProperties(BGColor, FrameTime, Fixation, NumberSaccade, Stimulus, RewardType,null, 0, null, events.NewInstant());
			return fr;
		}

		public void SetProperties(Color BGC, int FrameT, List<ObjectProp> FixationProp, int NumSaccade, FixationPts[] StimulusProp, int Reward, HintForm cue, int NumBox, ShowFr[] ShowBox, TriggerEvents ev)
		{
			BGColor = BGC;
			FrameTime = FrameT;
            Fixation = FixationProp.GetRange(0, FixationProp.Count);
			NumberSaccade = NumSaccade;
			Stimulus = new FixationPts[NumSaccade];
			for (int i = 0; i < NumSaccade; i++)
			{
				Stimulus[i] = new FixationPts();
				Stimulus[i] = StimulusProp[i];

			}
			RewardType = Reward;
			Cue = cue;
			ShowFrame = new ShowFr[NumBox];
			for (int i = 0; i < NumBox; i++)
			{
				ShowFrame[i] = ShowBox[i];
			}
			events = ev;
		}

		public static List<FrameProperties> Copy(List<FrameProperties> listin)
		{
			FrameProperties[] frIn = new FrameProperties[listin.Count];
			for (int i = 0; i < listin.Count; i++)
				frIn[i] = listin[i].Copy();
			return frIn.ToList();
		}
	}
	
    public class FixationPts
    {
        public int Xloc, Yloc, Width, Height,Type;
        public int Contrast;
        public Color ColorPt;
        public string PathPic;
        public int _correctEventCode, _incorrectEventCode, time;

        public FixationPts()
        {
            Xloc = -1;
            Yloc = -1;
            Width = 0;
            Type = 0;
            Contrast = 255;
            PathPic = "";
            ColorPt = Color.Black;
        }
        
        public void SetContrastPts(int contrast)
        {
            Contrast = contrast;
        }

        public void SetFixationPts(int x, int y, int w, int type, Color color)
        {
            Xloc = x;
            Yloc = y;
            Width = w;
            Type = type;
            ColorPt = color;
        }

        public void SetFixationPts(int x, int y, int w, int h, int type, Color color)
        {
            Xloc = x;
            Yloc = y;
            Width = w;
            Height = h;
            Type = type;
            ColorPt = color;
        }

        public void SetPicture(int x, int y, int w, int h,int type, String path )
        {
            Xloc = x;
            Yloc = y;
            Width = w;
            Height = h;
            Type = type;
            PathPic = path;
        }

    }

    public class HintForm
    {
        // 1 for arrow, 2 for box
        public int type;

        // 
        public int ArrowLocY, ArrowLocX0, ArrowLocX1;
        public int ArrowWidth;
        public Color ArrowColor;
        public int Valid;

        //
        public int BoxThickness;
        public float BoxRatio;
        public Color BoxColor;
        public ShowFr[] HintBoxes;

        public HintForm()
        {
            type = 0;
            ArrowLocY = 0;
            ArrowLocX0 = 0;
            ArrowLocX1 = 0;
            ArrowWidth = 0;
            ArrowColor = Color.Black;
            BoxThickness = 0;
            BoxRatio = 1;
            BoxColor = Color.Black;
            HintBoxes = new ShowFr[2];
        }

        public void SetArrowProp( int y, int x0, int x1, int validity, Color c)
        {
            ArrowLocY = y;
            ArrowLocX0 = x0;
            ArrowLocX1 = x1;
            Valid = validity;
            ArrowColor = c;
        }

        public void SetBoxProp(int thickness, float ratio, Color c)
        {
            BoxThickness = thickness;
            BoxRatio = ratio;
            BoxColor = c;
        }

        public void SetValidity (int validity)
        {
            Valid = validity;
        }

        //public int[] SetArrowBasedOnValidity ()
        //{
        //    int[] vararrow = new int[3];
        //    if(Valid)
        //    {
        //        vararrow[0] = ArrowLocX0;
        //        vararrow[1] = ArrowLocX1;
        //        vararrow[2] = ArrowLocY;
        //    }
        //    else
        //    {
        //        vararrow[0] = ArrowLocX1;
        //        vararrow[1] = ArrowLocX0;
        //        vararrow[2] = ArrowLocY;
        //    }
        //    return vararrow;
        //}


    }

	public class ShowFr
    {
        public int CenterX, CenterY, Width, Height;
        public float Thickness;
        public Color ColorBox;
        public ShowFr()
        {
            CenterX = 0;
            CenterY = 0;
            Width = 0;
            Height = 0;
            Thickness = 0;
            ColorBox = Color.Black;
        }


        public void SetShowFrameProp(int X, int Y, int w, int h, float thickness, Color boxcolor)
        {
            CenterX = X;
            CenterY = Y;
            Width = w;
            Height = h;
            Thickness = thickness;
            ColorBox = boxcolor;
        }

    }
}