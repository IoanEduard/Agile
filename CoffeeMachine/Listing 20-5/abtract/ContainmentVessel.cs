namespace CoffeeMachine.Listing_20_5
{
    public abstract class ContainmentVessel
    {
        private UserInterface _ui;
        private HotWaterSource _hws;
        protected bool isBrewing;
        protected bool isComplete;

        public ContainmentVessel()
        {
            isBrewing = false;
            isComplete = true;
        }

        public void Init(UserInterface ui, HotWaterSource hws)
        {
            _ui = ui;
            _hws = hws;
        }
        public void Start()
        {
            isBrewing = true;
            isComplete = false;
        }
        public void Done()
        {
            isBrewing = false;
        }
        protected void DeclareComplete()
        {
            isComplete = true;
            _ui.Complete();
        }
        protected void ContainerAvailable()
        {
            _hws.Resume();
        }
        protected void ContainerUnavailable()
        {
            _hws.Pause();
        }
        public abstract bool IsReady();
    }
}