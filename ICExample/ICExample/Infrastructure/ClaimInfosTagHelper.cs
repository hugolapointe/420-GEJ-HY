using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Security.Claims;

namespace ICExample.Infrastructure {
    [HtmlTargetElement("claim-infos", Attributes = "claim-type")]
    public class ClaimInfosTagHelper : TagHelper {

        [HtmlAttributeName("claim-type")]
        public string ClaimType { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            var fields = typeof(ClaimTypes).GetFields();

            var value = fields.FirstOrDefault(field => field.GetValue(null).ToString() == ClaimType);

            output.Content.SetContent(value?.Name ?? ClaimType.Split('/', '.').Last());
        }
    }
}
