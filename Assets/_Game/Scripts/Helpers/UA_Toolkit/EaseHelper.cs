using UnityEngine;

namespace UA.Toolkit.Ease
{
    public static class EaseHelper
    {
        #region Easing Curves

        public static float Linear(float value)
        {
            return Linear(0f, 1f, value);
        }

        public static float Linear(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, value);
        }

        public static float Slerp(float value)
        {
            return Slerp(0f, 1f, value);
        }

        public static float Slerp(float start, float end, float value)
        {
            float min = 0.0f;
            float max = 360.0f;
            float half = Mathf.Abs((max - min) * 0.5f);
            float retval = 0.0f;
            float diff = 0.0f;
            if ((end - start) < -half)
            {
                diff = ((max - start) + end) * value;
                retval = start + diff;
            }
            else if ((end - start) > half)
            {
                diff = -((max - end) + start) * value;
                retval = start + diff;
            }
            else retval = start + (end - start) * value;
            return retval;
        }

        public static float Spring(float value)
        {
            return Spring(0f, 1f, value);
        }

        public static float Spring(float start, float end, float value)
        {
            value = Mathf.Clamp01(value);
            value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
            return start + (end - start) * value;
        }

        public static float EaseInQuad(float value)
        {
            return EaseInQuad(0f, 1f, value);
        }

        public static float EaseInQuad(float start, float end, float value)
        {
            end -= start;
            return end * value * value + start;
        }

        public static float EaseOutQuad(float value)
        {
            return EaseOutQuad(0f, 1f, value);
        }

        public static float EaseOutQuad(float start, float end, float value)
        {
            end -= start;
            return -end * value * (value - 2) + start;
        }

        public static float EaseInOutQuad(float value)
        {
            return EaseInOutQuad(0f, 1f, value);
        }

        public static float EaseInOutQuad(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value + start;
            value--;
            return -end * 0.5f * (value * (value - 2) - 1) + start;
        }

        public static float EaseInCubic(float value)
        {
            return EaseInCubic(0f, 1f, value);
        }

        public static float EaseInCubic(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value + start;
        }

        public static float EaseOutCubic(float value)
        {
            return EaseOutCubic(0f, 1f, value);
        }

        public static float EaseOutCubic(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value + 1) + start;
        }

        public static float EaseInOutCubic(float value)
        {
            return EaseInOutCubic(0f, 1f, value);
        }

        public static float EaseInOutCubic(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value + start;
            value -= 2;
            return end * 0.5f * (value * value * value + 2) + start;
        }

        public static float EaseInQuart(float value)
        {
            return EaseInQuart(0f, 1f, value);
        }

        public static float EaseInQuart(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value * value + start;
        }

        public static float EaseOutQuart(float value)
        {
            return EaseOutQuart(0f, 1f, value);
        }

        public static float EaseOutQuart(float start, float end, float value)
        {
            value--;
            end -= start;
            return -end * (value * value * value * value - 1) + start;
        }

        public static float EaseInOutQuart(float value)
        {
            return EaseInOutQuart(0f, 1f, value);
        }

        public static float EaseInOutQuart(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value * value + start;
            value -= 2;
            return -end * 0.5f * (value * value * value * value - 2) + start;
        }

        public static float EaseInQuint(float value)
        {
            return EaseInQuint(0f, 1f, value);
        }

        public static float EaseInQuint(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value * value * value + start;
        }

        public static float EaseOutQuint(float value)
        {
            return EaseOutQuint(0f, 1f, value);
        }

        public static float EaseOutQuint(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value * value * value + 1) + start;
        }

        public static float EaseInOutQuint(float value)
        {
            return EaseInOutQuint(0f, 1f, value);
        }

        public static float EaseInOutQuint(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value * value * value + start;
            value -= 2;
            return end * 0.5f * (value * value * value * value * value + 2) + start;
        }

        public static Vector3 EaseInSine(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(
                EaseInSine(start.x, end.x, value),
                EaseInSine(start.y, end.y, value),
                EaseInSine(start.z, end.z, value)
            );
        }

        public static float EaseInSine(float value)
        {
            return EaseInSine(0f, 1f, value);
        }

        public static float EaseInSine(float start, float end, float value)
        {
            end -= start;
            return -end * Mathf.Cos(value * (Mathf.PI * 0.5f)) + end + start;
        }

        public static Vector3 EaseOutSine(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(
                EaseOutSine(start.x, end.x, value),
                EaseOutSine(start.y, end.y, value),
                EaseOutSine(start.z, end.z, value)
            );
        }

        public static float EaseOutSine(float value)
        {
            return EaseOutSine(0f, 1f, value);
        }

        public static float EaseOutSine(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Sin(value * (Mathf.PI * 0.5f)) + start;
        }

        public static float EaseInOutSine(float value)
        {
            return EaseInOutSine(0f, 1f, value);
        }

        public static float EaseInOutSine(float start, float end, float value)
        {
            end -= start;
            return -end * 0.5f * (Mathf.Cos(Mathf.PI * value) - 1) + start;
        }

        public static float EaseInExpo(float value)
        {
            return EaseInExpo(0f, 1f, value);
        }

        public static float EaseInExpo(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Pow(2, 10 * (value - 1)) + start;
        }

        public static float EaseOutExpo(float value)
        {
            return EaseOutExpo(0f, 1f, value);
        }

        public static float EaseOutExpo(float start, float end, float value)
        {
            end -= start;
            return end * (-Mathf.Pow(2, -10 * value) + 1) + start;
        }

        public static float EaseInOutExpo(float value)
        {
            return EaseInOutExpo(0f, 1f, value);
        }

        public static float EaseInOutExpo(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * Mathf.Pow(2, 10 * (value - 1)) + start;
            value--;
            return end * 0.5f * (-Mathf.Pow(2, -10 * value) + 2) + start;
        }

        public static float EaseInCirc(float value)
        {
            return EaseInCirc(0f, 1f, value);
        }

        public static float EaseInCirc(float start, float end, float value)
        {
            end -= start;
            return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
        }

        public static Vector3 EaseOutCirc(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(
                EaseOutCirc(start.x, end.x, value),
                EaseOutCirc(start.y, end.y, value),
                EaseOutCirc(start.z, end.z, value)
            );
        }

        public static float EaseOutCirc(float value)
        {
            return EaseOutCirc(0f, 1f, value);
        }

        public static float EaseOutCirc(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * Mathf.Sqrt(1 - value * value) + start;
        }

        public static float EaseInOutCirc(float value)
        {
            return EaseInOutCirc(0f, 1f, value);
        }

        public static float EaseInOutCirc(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return -end * 0.5f * (Mathf.Sqrt(1 - value * value) - 1) + start;
            value -= 2;
            return end * 0.5f * (Mathf.Sqrt(1 - value * value) + 1) + start;
        }

        public static float EaseInBounce(float value)
        {
            return EaseInBounce(0f, 1f, value);
        }

        /* GFX47 MOD START */
        public static float EaseInBounce(float start, float end, float value)
        {
            end -= start;
            float d = 1f;
            return end - EaseOutBounce(0, end, d - value) + start;
        }

        public static float EaseOutBounce(float value)
        {
            return EaseOutBounce(0f, 1f, value);
        }
        /* GFX47 MOD END */

        /* GFX47 MOD START */
        //private float bounce(float start, float end, float value){
        public static float EaseOutBounce(float start, float end, float value)
        {
            value /= 1f;
            end -= start;
            if (value < (1 / 2.75f))
            {
                return end * (7.5625f * value * value) + start;
            }
            else if (value < (2 / 2.75f))
            {
                value -= (1.5f / 2.75f);
                return end * (7.5625f * (value) * value + .75f) + start;
            }
            else if (value < (2.5 / 2.75))
            {
                value -= (2.25f / 2.75f);
                return end * (7.5625f * (value) * value + .9375f) + start;
            }
            else
            {
                value -= (2.625f / 2.75f);
                return end * (7.5625f * (value) * value + .984375f) + start;
            }
        }
        /* GFX47 MOD END */


        public static float EaseInOutBounce(float value)
        {
            return EaseInOutBounce(0f, 1f, value);
        }
        /* GFX47 MOD START */
        public static float EaseInOutBounce(float start, float end, float value)
        {
            end -= start;
            float d = 1f;
            if (value < d * 0.5f) return EaseInBounce(0, end, value * 2) * 0.5f + start;
            else return EaseOutBounce(0, end, value * 2 - d) * 0.5f + end * 0.5f + start;
        }
        /* GFX47 MOD END */

        public static float EaseInBack(float value)
        {
            return EaseInBack(0f, 1f, value);
        }

        public static float EaseInBack(float start, float end, float value)
        {
            end -= start;
            value /= 1;
            float s = 1.70158f;
            return end * (value) * value * ((s + 1) * value - s) + start;
        }

        public static float EaseOutBack(float value)
        {
            return EaseOutBack(0f, 1f, value);
        }

        public static float EaseOutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value = (value) - 1;
            return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
        }

        public static float EaseInOutBack(float value)
        {
            return EaseInOutBack(0f, 1f, value);
        }

        public static float EaseInOutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value /= .5f;
            if ((value) < 1)
            {
                s *= (1.525f);
                return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
            }
            value -= 2;
            s *= (1.525f);
            return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
        }

        public static float Punch(float amplitude, float value)
        {
            float s = 9;
            if (value == 0)
            {
                return 0;
            }
            else if (value == 1)
            {
                return 0;
            }
            float period = 1 * 0.3f;
            s = period / (2 * Mathf.PI) * Mathf.Asin(0);
            return (amplitude * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period));
        }

        public static float EaseInElastic(float value)
        {
            return EaseInElastic(0f, 1f, value);
        }

        /* GFX47 MOD START */
        public static float EaseInElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
        }

        public static float EaseOutElastic(float value)
        {
            return EaseOutElastic(0f, 1f, value);
        }
        /* GFX47 MOD END */

        /* GFX47 MOD START */
        //private float elastic(float start, float end, float value){
        public static float EaseOutElastic(float start, float end, float value)
        {
            /* GFX47 MOD END */
            //Thank you to rafael.marteleto for fixing this as a port over from Pedro's UnityTween
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p * 0.25f;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
        }

        public static float EaseInOutElastic(float value)
        {
            return EaseInOutElastic(0f, 1f, value);
        }

        /* GFX47 MOD START */
        public static float EaseInOutElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d * 0.5f) == 2) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            if (value < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
            return a * Mathf.Pow(2, -10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
        }
        /* GFX47 MOD END */

        #endregion
    }

}

