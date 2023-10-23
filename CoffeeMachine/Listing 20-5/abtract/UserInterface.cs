namespace CoffeeMachine.Listing_20_5
{
    public abstract class UserInterface
    {
        private HotWaterSource _hws;
        private ContainmentVessel _cv;
        protected bool _isCompleted;

        protected UserInterface()
        {
            _isCompleted = true;
        }

        public void Init(HotWaterSource hws, ContainmentVessel cv)
        {
            this._hws = hws;
            this._cv = cv;
        }


        public void Complete()
        {
            _isCompleted = true;
            CompleteCycle();
        }

        protected void StartBrewing()
        {
            if (_hws.IsReady() && _cv.IsReady())
            {
                _isCompleted = false;
                _hws.Start();
                _cv.Start();
            }
        }

        public abstract void Done();
        public abstract void CompleteCycle();
    }
}
