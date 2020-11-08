using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MessengerComparison
{
    public class MCHtmlBuilder
    {
        public static List<string> Languages { get; set; }
        Dictionary<string, string> GeneralData { get; set; }
        List<Group> ComparisonData { get; set; }
        string Language { get; set; }
        DateTime LastModified { get; set; }

        public MCHtmlBuilder(string language, Dictionary<string, string> generalData,
                             List<Group> comparisonData, DateTime lastModified)
        {
            Language = language;
            GeneralData = generalData;
            ComparisonData = comparisonData;
            LastModified = lastModified;
        }

        public string Build()
        {
            var html = string.Empty;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(
            $@"<!DOCTYPE html>
               <html lang=""{Language}"">
                    <head>
                        <meta http-equiv=""content-type"" content=""text/html; charset=utf-8"" />
                        <meta property=""og:site_name"" content=""MessengerComparison"">
                        <meta property=""og:title"" content=""{GeneralData["Headline"]}"">
                        <meta property=""og:description"" content=""{GeneralData["Description"]}"">
                        <meta property=""og:image"" content=""https://jayxt.github.io/MessengerComparison/preview.png"">                        
                        <title>MessengerComparison</title>
                        <link rel=""shortcut icon"" href=""../favicon.ico"" type=""image/x-icon"">
                        <link href=""https://fonts.googleapis.com/css?family=Noto+Sans"" rel=""stylesheet"">
                        <link rel=""stylesheet"" type=""text/css"" href=""../css/styles.css"">
                    </head>
                    <body>
                        <div class=""language"">
                            {GetLanguages()}
                        </div>
                        <section class=""main"">
                        <h1 class=""headline"">{GeneralData["Headline"]}</h1>
                        <div id=""ms-edge-wrapper"">
                            <table>
                                <colgroup>
                                    <col class=""group-col"">
                                    <col class=""aspect-col"">
                                    <col class=""feature-col"">
                                    <col class=""service-col"">
                                    <col class=""service-col"">
                                    <col class=""service-col"">
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th>{GeneralData["Group"]}</th>
                                        <th>{GeneralData["Aspect"]}</th>
                                        <th>{GeneralData["Feature"]}</th>
                                        <th>
                                            <span class=""telegram-icon"">{GeneralData["Telegram"]}</span>
                                        </th>
                                        <th>
                                            <span class=""viber-icon"">{GeneralData["Viber"]}</span>
                                        </th>
                                        <th>
                                            <span class=""whatsapp-icon"">{GeneralData["WhatsApp"]}</span>
                                        </th>
                                    </tr>                            
                                </thead>
                                <tbody>
            ");

            string value = string.Empty;
            string score = string.Empty;
            int groupRowspan, aspectRowspan;
            bool groupWasAdded, aspectWasAdded;

            foreach(var group in ComparisonData)
            {                        
                groupRowspan = group.GetRowCount();
                groupWasAdded = false;

                foreach(var aspect in group.Aspects)
                {
                    aspectRowspan = aspect.Features.Count;
                    aspectWasAdded = false;
                    bool TelegramFeaturesPresent = aspect.AreTelegramFeaturesPresent();
                    bool ViberFeaturesPresent = aspect.AreViberFeaturesPresent();
                    bool WhatsAppFeaturesPresent = aspect.AreWhatsAppFeaturesPresent();

                    foreach(var feature in aspect.Features)
                    {
                        builder.AppendLine(
                            "<tr>");                                    
                            if(!groupWasAdded)
                            {
                                builder.AppendLine($@"
                                <td rowspan=""{groupRowspan}"">
                                    <h3 class=""group-text"">{group.GroupName}</h3>
                                </td>
                                ");
                            }

                            if(!aspectWasAdded)
                            {
                                builder.AppendLine($@"
                                <td rowspan=""{aspectRowspan}"">
                                    <h4 class=""aspect-text"">{aspect.AspectName}</h4>
                                </td>
                                ");
                            }
                            builder.AppendLine($@"
                                <td>{feature.FeatureName.ToHtml()}</td>
                            ");


                            if(feature.Telegram != null) 
                            {
                                (score, value) =  feature.Telegram.GetScoreValue();
                                builder.AppendLine($@"
                                <td class=""{score}"">{value}</td>
                                ");
                            }
                            else if(TelegramFeaturesPresent && feature.Telegram == null) 
                            {
                                builder.AppendLine($@"
                                <td class=""disadvantage"">&#8212;</td>
                                ");
                            }
                            else if(!aspectWasAdded && !TelegramFeaturesPresent && aspect.Telegram != null)
                            {
                                (score, value) =  aspect.Telegram.GetScoreValue();                                        
                                builder.AppendLine($@"
                                <td class=""{score}"" rowspan=""{aspectRowspan}"">{value}</td>
                                ");
                            }
                            else if(!aspectWasAdded && !TelegramFeaturesPresent && aspect.Telegram == null) 
                            {
                                builder.AppendLine($@"
                                <td class=""disadvantage"" rowspan=""{aspectRowspan}"">&#8212;</td>
                                ");
                            }


                            if(feature.Viber != null) 
                            {
                                (score, value) = feature.Viber.GetScoreValue();
                                builder.AppendLine($@"
                                <td class=""{score}"">{value}</td>
                                ");
                            }
                            else if(ViberFeaturesPresent && feature.Viber == null) 
                            {
                                builder.AppendLine($@"
                                <td class=""disadvantage"">&#8212;</td>
                                ");
                            }
                            else if(!aspectWasAdded && !ViberFeaturesPresent && aspect.Viber != null)
                            {
                                (score, value) = aspect.Viber.GetScoreValue();
                                builder.AppendLine($@"
                                <td class=""{score}"" rowspan=""{aspectRowspan}"">value</td>
                                ");
                            }
                            else if(!aspectWasAdded && !ViberFeaturesPresent && aspect.Viber == null) 
                            {
                                builder.AppendLine($@"
                                <td class=""disadvantage"" rowspan=""{aspectRowspan}"">&#8212;</td>
                                ");
                            }


                            if(feature.WhatsApp != null) 
                            {
                                (score, value) = feature.WhatsApp.GetScoreValue();
                                builder.AppendLine($@"
                                <td class=""{score}"">{value}</td>
                                ");
                            }
                            else if(WhatsAppFeaturesPresent && feature.WhatsApp == null) 
                            {
                                builder.AppendLine($@"
                                <td class=""disadvantage"">&#8212;</td>
                                ");
                            }
                            else if(!aspectWasAdded && !WhatsAppFeaturesPresent && aspect.WhatsApp != null)
                            {
                                (score, value) = aspect.WhatsApp.GetScoreValue();
                                builder.AppendLine($@"
                                <td class=""{score}"" rowspan=""{aspectRowspan}"">{value}</td>
                                ");
                            }
                            else if(!aspectWasAdded && !WhatsAppFeaturesPresent && aspect.WhatsApp == null) 
                            {
                                builder.AppendLine($@"
                                <td class=""disadvantage"" rowspan=""{aspectRowspan}"">&#8212;</td>
                                ");
                            }

                            groupWasAdded = true;
                            aspectWasAdded = true;
                        builder.AppendLine($@"
                        </tr>");
                    }
                }                        
            }

            builder.AppendLine($@"
                                    </tbody>
                                </table>
                            </div>
                            <p class=""updated-date"">
                                {GetLastModifiedText()}  <br><br>
                                {GeneralData["Author"].ToHtml()}
                            </p>
                        </section>
                    </body>
                </html>
                ");

            return builder.ToString();
        }

        public string GetLanguages()
        {
            var languagesHtml = string.Empty;

            foreach (var lang in Languages)
                languagesHtml += (lang == Language) ?
                 $"<h4>{lang.ToUpper()}</h4>\n" :
                 $"<a href=\"../{lang}\">{lang.ToUpper()}</a>\n";

            return languagesHtml;
        }

        public string GetLastModifiedText()
        {

            CultureInfo ci;

            var textPrefix = GeneralData["UpdatedText"] + " ";
            
            if(GeneralData.ContainsKey("UpdatedDate") &&
               !string.IsNullOrEmpty(GeneralData["UpdatedDate"]))
                return textPrefix + GeneralData["UpdatedDate"];

            switch (Language)
            {
                case "en":
                    ci = new CultureInfo("en-US");
                    return textPrefix + LastModified.ToString(@"dd \o\f MMMM, yyyy", ci);
                case "pt":
                    ci = new CultureInfo("pt-BR");
                    return textPrefix + LastModified.ToString(@"dd \d\e MMMM \d\e yyyy", ci);
                case "ru":
                    ci = new CultureInfo("ru-RU");
                    return textPrefix + LastModified.ToString(@"dd MMMM yyyy \г.", ci);
                case "uk":
                    ci = new CultureInfo("uk-UA");
                    return textPrefix + LastModified.ToString(@"dd MMMM yyyy \р.", ci);
                default:
                    ci = CultureInfo.InvariantCulture;
                    return textPrefix + LastModified.ToString(@"MM/dd/yyyy", ci);
            }
        }

    }
}