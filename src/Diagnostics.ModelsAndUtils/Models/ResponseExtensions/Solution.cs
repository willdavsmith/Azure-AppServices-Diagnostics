﻿using System;
using System.Collections.Generic;
using Diagnostics.ModelsAndUtils.ScriptUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Diagnostics.ModelsAndUtils.Models.ResponseExtensions
{
    public class Solution
    {
        /// <summary>
        /// Name of the Solution.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Solution title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A description which will be rendered as Markdown.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Denotes which action will be performed, such as calling an ARM API or navigating to a Portal Blade.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionType Action { get; set; }

        /// <summary>
        /// If the solution requires confirmation, it will signify a potentially dangerous action in the UI.
        /// </summary>
        public bool RequiresConfirmation { get; set; }

        /// <summary>
        /// The URI of the target resource on which an action will be performed.
        /// </summary>
        public string ResourceUri { get; set; }

        /// <summary>
        /// Instructions that will be sent to the customer by support staff. Rendered as Markdown.
        /// </summary>
        public string InternalInstructions { get; set; }

        /// <summary>
        /// Free-form JSON-serializable arguments that can be sent as the body of the action request if a request
        /// body is applicable.
        /// </summary>
        public Dictionary<string, object> ActionOptions { get; set; }

        /// <summary>
        /// This is set automatically.
        /// Reads <see cref="OperationContext"/> to determine if an internal view should be rendered.
        /// </summary>
        public bool IsInternal { get; set; } = false;

        /// <summary>
        /// This is set automatically.
        /// Used to create a deep link back to the Solution's detector in case the customer is receiving
        /// Solution information from support staff.
        /// </summary>
        public string DetectorId { get; set; }

        /// <summary>
        /// Set the ResourceUri and optionally set the ActionOptions for the Solution to use.
        /// </summary>
        // TODO: actionOptions has to merge with existing options in case detector author adds to solution author's options
        public Solution Using(string resourceUri, Dictionary<string, object> actionOptions = null)
        {
            ResourceUri = resourceUri;

            if (actionOptions != null)
            {
                ActionOptions = actionOptions;
            }

            return this;
        }
    }
}
