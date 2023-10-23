using CoffeeMachine.Listing_20_1;

namespace CoffeeMachine.Listing_20_5
{
    public class M4ContainmentVessel : ContainmentVessel, IPollable
    {
        private ICoffeeMakerAPI _coffeeMaker;
        private WarmerPlateStatus _lastPotStatus;

        public M4ContainmentVessel(ICoffeeMakerAPI coffeeMaker)
        {
            _coffeeMaker = coffeeMaker;
            _lastPotStatus = WarmerPlateStatus.POT_EMPTY;
        }

        public override bool IsReady()
        {
            WarmerPlateStatus status = _coffeeMaker.GetWarmerPlateStatus();
            return status == WarmerPlateStatus.POT_EMPTY;
        }

        public void Poll()
        {
            WarmerPlateStatus potStatus = _coffeeMaker.GetWarmerPlateStatus();
            if (potStatus != _lastPotStatus)
            {
                if (isBrewing)
                {
                    HandleBrewingEvent(potStatus);
                }
                else if (isComplete == false)
                {
                    HandleIncompleteEvent(potStatus);
                }
                _lastPotStatus = potStatus;
            }
        }

        private void HandleIncompleteEvent(WarmerPlateStatus potStatus)
        {
            if (potStatus == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                ContainerAvailable();
                _coffeeMaker.SetWarmerState(WarmerState.ON);
            }
            else if (potStatus == WarmerPlateStatus.WARMER_EMPTY)
            {
                ContainerUnavailable();
                _coffeeMaker.SetWarmerState(WarmerState.OFF);
            }
            else
            {
                ContainerAvailable();
                _coffeeMaker.SetWarmerState(WarmerState.OFF);
            }
        }

        private void HandleBrewingEvent(WarmerPlateStatus potStatus)
        {
            if (potStatus == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                _coffeeMaker.SetWarmerState(WarmerState.ON);
            }
            else if (potStatus == WarmerPlateStatus.WARMER_EMPTY)
            {
                _coffeeMaker.SetWarmerState(WarmerState.OFF);
            }
            else
            {
                _coffeeMaker.SetWarmerState(WarmerState.OFF);
                DeclareComplete();
            }
        }
    }
}
