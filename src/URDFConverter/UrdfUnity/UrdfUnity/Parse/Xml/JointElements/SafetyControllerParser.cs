﻿using System.Xml;
using UrdfUnity.Urdf.Models.JointElements;
using UrdfUnity.Util;

namespace UrdfUnity.Parse.Xml.JointElements
{
    /// <summary>
    /// Parses a URDF &lt;safety_controller&gt; element from XML into a SafetyController object.
    /// </summary>
    /// <seealso cref="http://wiki.ros.org/urdf/XML/joint"/>
    /// <seealso cref="Urdf.Models.JointElements.SafetyController"/>
    public class SafetyControllerParser : XmlParser<SafetyController>
    {
        private static readonly string LOWER_LIMIT_ATTRIBUTE_NAME = "soft_lower_limit";
        private static readonly string UPPER_LIMIT_ATTRIBUTE_NAME = "soft_upper_limit";
        private static readonly string K_POSITION_ATTRIBUTE_NAME = "k_position";
        private static readonly string K_VELOCITY_ATTRIBUTE_NAME = "k_velocity";
        private static readonly double DEFAULT_VALUE = 0d;


        /// <summary>
        /// Parses a URDF &lt;safety_controller&gt; element from XML.
        /// </summary>
        /// <param name="node">The XML node of a &lt;safety_controller&gt; element</param>
        /// <returns>An SafetyController object parsed from the XML</returns>
        public SafetyController Parse(XmlNode node)
        {
            Preconditions.IsNotNull(node, "node");

            XmlAttribute lowerLimitAttribute = (node.Attributes != null ? (XmlAttribute)node.Attributes.GetNamedItem(LOWER_LIMIT_ATTRIBUTE_NAME) : null);
            XmlAttribute upperLimitAttribute = (node.Attributes != null ? (XmlAttribute)node.Attributes.GetNamedItem(UPPER_LIMIT_ATTRIBUTE_NAME) : null);
            XmlAttribute positionAttribute = (node.Attributes != null ? (XmlAttribute)node.Attributes.GetNamedItem(K_POSITION_ATTRIBUTE_NAME) : null);
            XmlAttribute velocityAttribute = (node.Attributes != null ? (XmlAttribute)node.Attributes.GetNamedItem(K_VELOCITY_ATTRIBUTE_NAME) : null);
            double lowerLimit = ParseAttribute(lowerLimitAttribute);
            double upperLimit = ParseAttribute(upperLimitAttribute);
            double position = ParseAttribute(positionAttribute);
            double velocity = ParseAttribute(velocityAttribute);

            if (velocityAttribute == null)
            {
                // TODO: Log missing required <safety_controller> k_velocity attribute
            }

            return new SafetyController(lowerLimit, upperLimit, position, velocity);
        }

        private double ParseAttribute(XmlAttribute attribute)
        {
            double value = DEFAULT_VALUE;

            if (attribute != null)
            {
                value = RegexUtils.MatchDouble(attribute.Value, DEFAULT_VALUE);
            }

            return value;
        }
    }
}
