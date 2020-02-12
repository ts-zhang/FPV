namespace JoystickRecord
{
    /**
     * 舵机行程范围
     */
    public class TravelRange
    {
        private int throttleMin;
        private int throttleMax;

        private int yawMin;
        private int yawMax;

        private int pitchMin;
        private int pitchMax;

        private int rollMin;
        private int rollMax;

        public int ThrottleMin
        {
            get { return throttleMin; }
            set { throttleMin = value; }
        }

        public int ThrottleMax
        {
            get { return throttleMax; }
            set { throttleMax = value; }
        }

        public int YawMin
        {
            get { return yawMin; }
            set { yawMin = value; }
        }

        public int YawMax
        {
            get { return yawMax; }
            set { yawMax = value; }
        }

        public int PitchMin
        {
            get { return pitchMin; }
            set { pitchMin = value; }
        }

        public int PitchMax
        {
            get { return pitchMax; }
            set { pitchMax = value; }
        }

        public int RollMin
        {
            get { return rollMin; }
            set { rollMin = value; }
        }

        public int RollMax
        {
            get { return rollMax; }
            set { rollMax = value; }
        }
    }
}