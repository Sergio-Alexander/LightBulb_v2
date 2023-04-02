// Type Definition Class Lumen

using System;

namespace standard
{
    public class Lumen
    {
        // Class Invariants:
        // 1. size is always positive
        // 2. reset_threshold is always positive
        // 3. power_threshold is always non-negative
        // 4. dimming_value is always non-negative
        // 5. brightness_copy and power_copy store initial values of brightness and power, respectively


        private const int INACTIVE_STATE = 0;
        private readonly int brightness_copy;
        private readonly int power_copy;
        private readonly int reset_threshold;
        private readonly int power_threshold;
        private readonly int dimming_value;

        private int brightness;
        private int size;
        private int power;
        private int glow_request;

        // Preconditions: input_brightness, input_size, and input_power are positive
        //                input_dimming_value, input_reset_threshold, and input_power_threshold are non-negative
        // Postconditions: Lumen object is created with given input values
        public Lumen(int input_brightness, int input_size, int input_power, int input_dimming_value, int input_reset_threshold, int input_power_threshold)
        {
            brightness = input_brightness;
            size = input_size;
            power = input_power;

            glow_request = 0;
            dimming_value = input_dimming_value;

            reset_threshold = input_reset_threshold;
            power_threshold = input_power_threshold;

            brightness_copy = input_brightness;
            power_copy = input_power;
        }

        // Preconditions: None
        // Postconditions: Returns the glow value based on the state of the Lumen object
        public int glow()
        {
            glow_request++;
            power--;

            if (!isActive())
            {
                return dimming_value;
            }

            if (isErratic())
            { 
                return ErraticValue();
            }

            return brightness * size;
        }

        // Preconditions: None
        // Postconditions: Resets the Lumen object if conditions are met, otherwise reduces brightness by 1
        public void reset()
        {
            if (resetRequest())
            {
                power = power_copy;
                brightness = brightness_copy;
                glow_request = 0;
            }
            else 
            {
                brightness--;
            }
        }

        // Implementation Invariants:
        // 1. ErraticValue() returns a non-negative value less than the current power

        private int ErraticValue()
        {
            Random random_number = new Random();
            return random_number.Next(power);
        }

        // Preconditions: None
        // Postconditions: Returns true if the Lumen object is active, otherwise false
        private bool isActive(){ return power > power_threshold; }

        // Preconditions: None
        // Postconditions: Returns true if the Lumen object is erratic, otherwise false

        private bool isErratic(){ return power <= power_threshold && power > INACTIVE_STATE; }

        // Preconditions: None
        // Postconditions: Returns true if the reset request is valid, otherwise false
        private bool resetRequest(){ return glow_request > reset_threshold && power > INACTIVE_STATE; }
    }
}
