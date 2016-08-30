using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MvvmCross.Core.IOSLib.Helper
{
    public sealed class AutoLayoutHelper
    {
        //STATCODE_CA1053 
        private AutoLayoutHelper() { }
        public static NSLayoutConstraint SetHeight(UIView target, nfloat height, string indentifier = "")
        {
            if (target != null)     //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    target,
                    NSLayoutAttribute.Height,
                    NSLayoutRelation.Equal,
                    null,
                    NSLayoutAttribute.NoAttribute,
                    1,
                    height
                );

                constraint.SetIdentifier(indentifier);
                target.AddConstraint(constraint);
                return constraint;
            }

            return null;
        }

        public static NSLayoutConstraint SetWidth(UIView target, nfloat width, string indentifier = "")
        {
            if (target != null)         //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    target,
                    NSLayoutAttribute.Width,
                    NSLayoutRelation.Equal,
                    null,
                    NSLayoutAttribute.NoAttribute,
                    1,
                    width
                );
                constraint.SetIdentifier(indentifier);
                target.AddConstraint(constraint);
                return constraint;
            }

            return null;
        }

        /// <summary>        
        /// STATCODE_CA1709
        /// </summary>
        public static NSLayoutConstraint SetRelativeHeight(UIView ancestor, UIView outer, UIView inner, nfloat ratio, string indentifier = "")
        {
            if (ancestor != null)       //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    inner,
                    NSLayoutAttribute.Height,
                    NSLayoutRelation.Equal,
                    outer,
                    NSLayoutAttribute.Height,
                    ratio,
                    0
                );
                constraint.SetIdentifier(indentifier);
                ancestor.AddConstraint(constraint);
                return constraint;
            }

            return null;
        }

        /// <summary>        
        /// STATCODE_CA1709
        /// </summary>
        public static NSLayoutConstraint SetRelativeWidth(UIView ancestor, UIView outer, UIView inner, nfloat ratio, string indentifier = "")
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                inner,
                NSLayoutAttribute.Width,
                NSLayoutRelation.Equal,
                outer,
                NSLayoutAttribute.Width,
                ratio,
                0
            );
            constraint.SetIdentifier(indentifier);
            ancestor.AddConstraint(constraint);
            return constraint;
        }

        public static NSLayoutConstraint FollowControlVertically(UIView ancestor, UIView first, UIView next, nfloat margin, string indentifier = "")
        {
            if (ancestor != null)       //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    next,
                    NSLayoutAttribute.Top,
                    NSLayoutRelation.Equal,
                    first,
                    NSLayoutAttribute.Bottom,
                    1,
                    margin
                );
                constraint.SetIdentifier(indentifier);
                ancestor.AddConstraint(constraint);
                return constraint;
            }

            return null;
        }

        public static NSLayoutConstraint FollowControlHorizontally(UIView ancestor, UIView first, UIView next, nfloat margin, string indentifier = "")
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                next,
                NSLayoutAttribute.Left,
                NSLayoutRelation.Equal,
                first,
                NSLayoutAttribute.Right,
                1,
                margin
            );
            constraint.SetIdentifier(indentifier);
            ancestor.AddConstraint(constraint);
            return constraint;
        }

        public static NSLayoutConstraint CenterControlHorizontally(UIView outer, UIView inner, string indentifier = "")
        {
            if (outer != null)          //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    inner,
                    NSLayoutAttribute.CenterX,
                    NSLayoutRelation.Equal,
                    outer,
                    NSLayoutAttribute.CenterX,
                    1,
                    0
                );
                constraint.SetIdentifier(indentifier);
                outer.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint CenterControlVertically(UIView outer, UIView inner, string indentifier = "")
        {
            if (outer != null)          //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    inner,
                    NSLayoutAttribute.CenterY,
                    NSLayoutRelation.Equal,
                    outer,
                    NSLayoutAttribute.CenterY,
                    1,
                    0
                );
                constraint.SetIdentifier(indentifier);
                outer.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint AlignBaselines (UIView ancestor, UIView fixedControl, UIView controlToAlign, string indentifier = "")
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                controlToAlign,
                NSLayoutAttribute.Baseline,
                NSLayoutRelation.Equal,
                fixedControl,
                NSLayoutAttribute.Baseline,
                1,
                0
            );
            constraint.SetIdentifier(indentifier);
            ancestor.AddConstraint(constraint);

            return constraint;
        }

        public static NSLayoutConstraint AlignTops (UIView ancestor, UIView fixedControl, UIView controlToAlign, string indentifier = "" )
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                controlToAlign,
                NSLayoutAttribute.Top,
                NSLayoutRelation.Equal,
                fixedControl,
                NSLayoutAttribute.Top,
                1,
                0
            );
            constraint.SetIdentifier(indentifier);
            ancestor.AddConstraint(constraint);

            return constraint;
        }

        public static NSLayoutConstraint AlignCentersHorizontally(UIView ancestor, UIView fixedControl, UIView controlToCenter, string indentifier = "")
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                controlToCenter,
                NSLayoutAttribute.CenterX,
                NSLayoutRelation.Equal,
                fixedControl,
                NSLayoutAttribute.CenterX,
                1,
                0
            );
            constraint.SetIdentifier(indentifier);
            ancestor.AddConstraint(constraint);

            return constraint;
        }

        public static NSLayoutConstraint AlignCentersVertically(UIView ancestor, UIView fixedControl, UIView controlToCenter, string indentifier = "")
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                controlToCenter,
                NSLayoutAttribute.CenterY,
                NSLayoutRelation.Equal,
                fixedControl,
                NSLayoutAttribute.CenterY,
                1,
                0
            );
            constraint.SetIdentifier(indentifier);
            ancestor.AddConstraint(constraint);

            return constraint;
        }

        public static NSLayoutConstraint AttachToParentLeft(UIView parent, UIView child, nfloat margin, string indentifier = "")
        {
            if (parent != null)         //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    child,
                    NSLayoutAttribute.Left,
                    NSLayoutRelation.Equal,
                    parent,
                    NSLayoutAttribute.Left,
                    1,
                    margin
                );
                constraint.SetIdentifier(indentifier);
                parent.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint AttachToParentRight(UIView parent, UIView child, nfloat margin, string indentifier = "")
        {
            if (parent != null)         //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    parent,
                    NSLayoutAttribute.Right,
                    NSLayoutRelation.Equal,
                    child,
                    NSLayoutAttribute.Right,
                    1,
                    margin
                );
                constraint.SetIdentifier(indentifier);
                parent.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint AttachToParentTop(UIView parent, UIView child, nfloat margin, string indentifier = "")
        {
            if (parent != null)         //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    child,
                    NSLayoutAttribute.Top,
                    NSLayoutRelation.Equal,
                    parent,
                    NSLayoutAttribute.Top,
                    1,
                    margin
                );
                constraint.SetIdentifier(indentifier);
                parent.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint AttachToParentBottom(UIView parent, UIView child, nfloat margin, string indentifier = "")
        {
            if (parent != null)         //StaticCode_CA1062
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    parent,
                    NSLayoutAttribute.Bottom,
                    NSLayoutRelation.Equal,
                    child,
                    NSLayoutAttribute.Bottom,
                    1,
                    margin
                );
                constraint.SetIdentifier(indentifier);
                parent.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint[] AttachToParentHorizontally(UIView parent, UIView child, nfloat margin, string indentifier = "")
        {
            NSLayoutConstraint[] result = new NSLayoutConstraint[2];

            result[0] = AttachToParentLeft(parent, child, margin, $"{indentifier}-left");
            result[1] = AttachToParentRight(parent, child, margin, $"{indentifier}-right");

            return result;
        }

        public static NSLayoutConstraint[] AttachToParentVertically(UIView parent, UIView child, nfloat margin, string indentifier = "")
        {
            NSLayoutConstraint[] result = new NSLayoutConstraint[2];

            result[0] = AttachToParentBottom(parent, child, margin, $"{ indentifier}-bottom");
            result[1] = AttachToParentTop(parent, child, margin, $"{ indentifier}-top"); 

            return result;
        }

        public static NSLayoutConstraint AttachToTopLevelGuide (UIView parent, IUILayoutSupport topGuide, UIView child, nfloat margin, string indentifier = "" )
        {
            NSLayoutConstraint result = NSLayoutConstraint.Create
            (
                child,
                NSLayoutAttribute.Top,
                NSLayoutRelation.Equal,
                topGuide,
                NSLayoutAttribute.Bottom,
                1,
                margin
            );
            result.SetIdentifier(indentifier);
            parent.AddConstraint(result);

            return result;
        }

        public static NSLayoutConstraint AttachToBottomLevelGuide (UIView parent, IUILayoutSupport bottomGuide, UIView child, nfloat margin, string indentifier = "")
        {
            NSLayoutConstraint result = NSLayoutConstraint.Create
            (
                bottomGuide,
                NSLayoutAttribute.Top,
                NSLayoutRelation.Equal,
                child,
                NSLayoutAttribute.Bottom,
                1,
                margin
            );
            result.SetIdentifier(indentifier);
            parent.AddConstraint(result);

            return result;
        }
    }
}