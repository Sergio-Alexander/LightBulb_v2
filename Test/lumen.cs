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

        private int dimming_threshold;
        private int reset_threshold;

        private int brightness_copy;
        private int power_copy;

        public Lumen(int brightness, int size, int power, int dimming_threshold, int reset_threshold){
            this.brightness = brightness;
            this.size = size;
            this.power = power;
            this.glow_request = 0;
            this.dimming_threshold = dimming_threshold;
            this.reset_threshold = reset_threshold;

            this.brightness_copy = brightness;
            this.power_copy = power;
        }

        public int glow(){
            if (power <= INACTIVE_STATE){
                return dimming_threshold;
            }

            glow_request++;
            power--;

            if (power > dimming_threshold){
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
            else if (brightness > INACTIVE_STATE){
                brightness--;
            }
        }

        private int ErraticValue(){
            Random random_number = new Random();
            return random_number.Next(power);
        }
    }
}