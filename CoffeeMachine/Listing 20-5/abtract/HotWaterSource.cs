namespace CoffeeMachine.Listing_20_5
{
    public abstract class HotWaterSource
    {
        private UserInterface _ui;
        private ContainmentVessel _cv;
        protected bool isBrewing;

        public HotWaterSource()
        {
            isBrewing = false;
        }

        public void Init(UserInterface ui, ContainmentVessel cv)
        {
            this._ui = ui;
            this._cv = cv;
        }

        public void Start()
        {
            isBrewing = true;
            StartBrewing();
        }
        public void Done()
        {
            isBrewing = false;
        }
        protected void DeclareDone()
        {
            _ui.Done();
            _cv.Done();
            isBrewing = false;
        }
        public abstract bool IsReady();
        public abstract void StartBrewing();
        public abstract void Pause();
        public abstract void Resume();


    }
}