using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue = 0;
        private float m_MaxValue;
        private string m_ProblematicFieldName;

        public ValueOutOfRangeException(string i_ProblematicFieldName, float i_MinVal, float i_MaxVal) : base(string.Format("The value for {0} is not in range, enter value between {1} to {2}", i_ProblematicFieldName, i_MinVal, i_MaxVal))
        {
            m_ProblematicFieldName = i_ProblematicFieldName;
            m_MinValue = i_MinVal;
            m_MaxValue = i_MaxVal;
        }

        public ValueOutOfRangeException(float i_MinVal, float i_MaxVal) : base(string.Format("The amount is not in range, enter amount between {0} to {1}", i_MinVal, i_MaxVal)) // Power related fields c`tor
        {
            m_MinValue = i_MinVal;
            m_MaxValue = i_MaxVal;
        }

        public float GetMaxValue
        {
            get
            {
                return m_MaxValue;
            }

            set
            {
                m_MaxValue = value;
            }
        }

        public float GetMinValue
        {
            get
            {
                return m_MinValue;
            }

            set
            {
                m_MinValue = value;
            }
        }
    }
}
