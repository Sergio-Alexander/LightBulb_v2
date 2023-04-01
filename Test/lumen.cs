// Type Definition Class Lumen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace standard{
    public class Lumen{
        private const int INACTIVE_STATE = 0;
        private int brightness;
        private int size;
        private int power;

        private int glow_request;
        private int dimming_value;

       
        private int reset_threshold;
        private int power_threshold;

        private int brightness_copy;
        private int power_copy;

        public Lumen(int input_brightness, int input_size, int input_power, int input_dimming_value, int input_reset_threshold, int input_power_threshold)
        {
            this.brightness = input_brightness;
            this.size = input_size;
            this.power = input_power;

            this.glow_request = 0;
            this.dimming_value = input_dimming_value;

            this.reset_threshold = input_reset_threshold;
            this.power_threshold = input_power_threshold;

            this.brightness_copy = input_brightness;
            this.power_copy = input_power;
        }

        public int glow(){
            if (isActive() == false){
                return dimming_value;
            }

            glow_request++;
            power--;

            if (isActive() == true){
                return brightness * size;
            }

            return ErraticValue();
        }

        public void reset(){
            if ((glow_request > reset_threshold) && (power > INACTIVE_STATE)){
                power = power_copy;
                brightness = brightness_copy;
                glow_request = 0;
            }
            else {
                brightness--;
            }
        }

        private int ErraticValue(){
            Random random_number = new Random();
            return random_number.Next(power);
        }

        public bool isActive()
        {
            if (power <= power_threshold)
            {
                return false;
            }
            return true;
        }
    }
}