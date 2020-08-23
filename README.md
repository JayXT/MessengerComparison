# MessengerComparison
A project aimed at providing thorough comparison of Telegram, Viber and WhatsApp messengers.
This repository is currently targetting Ukrainian, English, Portuguese and Russian localization.
The comparison table is available via following URLs:

- https://messenger-comparison.azurewebsites.net/en

- https://jayxt.github.io/MessengerComparison/en

Current Maintainers:
- JayXT: EN, UK
- Hookz: RU
- David S.: IT
- Teuscard: PT (translation is out-of-date)


If you want to create a translation for your lanuage of choice, feel free to become a contributor of this repository by creating a separate git branch for your translation. To translate the page you have to:

1) Create two letter subfolder indicating your language in the data folder.
2) Copy general-data.json, comparison-data.json files from other language folder (preferrably **uk** or **en**) into your folder.
3) Translate right-hand side values in these JSON files to your language similar to how this had been done for other languages. Keep field names and advantage/mediocrity/disadvantage prefix with pipe character ("|") intact.
4) When the translation is finished, create a pull request from your branch into master. It will get approved and merged in shortly.


Please make sure that:

1) Your JSON has the exact structure as in en/uk versions.
2) Your translation is accurate enough and upper/lower-case letters are applied the same way as in original page.

To get approval of pull request into this repository's master branch, please focus on changing data/[your_language]/ files only. 
In case if these files meet all conditions, the pull request will get merged, the page will be added to repository and README.md will be updated.


**Questions & Answers**

Q: How my translation updates are delivered?

A: When your changes are merged into master branch, this triggers GitHub workflow which runs .NET Core MessengerComparison project, in turn it generates static website based on representation files as well as language data files. The resulting changes added to Output folder are commmited and pushed by the GitHub workflow into gh-pages branch which is used to access the website. The deployment to Azure instance of website  (messenger-comparison.azurewebsites.net) is triggered based on commits to gh-pages branch via Azure Kudu service.


Q: Why there are lots of missing messenger values in JSON files?

A: If the value for a particular messenger is missing in the JSON structure, it's considered as disadvantage and "—" default value will be used. This was done to avoid proliferation of duplicated values and simplify translation maintenance.


Q: What is the priority for messenger values selection from JSON?

A: The final value for each messenger is selected according to these rules:

1) Feature-level value is used whenever available.
2) If feature-level value is not present, but there are other feature-level values on the same aspect, "—" disadvantage for this feature is chosen.
3) If there are no feature-level values for the aspect, then the aspect-level value is selected.
4) If neither feature-level values, nor aspect-level value is available, "—" disadvantage is used on the aspect level.


Q: Why only these three messengers are selected?

A: When I came up with an idea of MessengerComparison, I've decided to select only these three because:
- Telegram is the cream of the crop solution with open philosophy, state-of-the-art technologies, unparalleled user experience and evolved ecosystem. Despite numerous advantages, some users still don't know about it, so it's worth to raise awareness about Telegram.
- Viber is one of the closest Telegram competitors, which shares lots of its features and is comparable in terms of MAU, though falls short in terms of technical architecture, UI/UX and openness.
- WhatsApp is by far the most widely-spread and well-known messenger that is simple and easy to use. Nonetheless, it has downsides when it comes to limited feature-set and architecture, parent company and privacy scandals. These also have to be shown.


Q: Can you add messenger "A", etc.?

A: No, it's not a priority. The reasons not to include other contenders:

1) Adding each new messaging service will induce decent increase of maintenance efforts on a regular basis. Since it's an open-source project maintained by volunteers in their free time, the primary focus was to limit comprehensive comparison just to these three options and consequently save our work-life balance:)
2) Some other solutions could measure up to Telegram in terms of speed & reliability or privacy & security or power & extensibility, but rarely all at once. There are messengers close to WhatsApp as far as features and with security on par with Telegram, or messengers that are chock-full of features, but have as many ads as Viber. However, very few could go toe to toe with any of these three if general balance and number of active users are concerned.
3) Each new messenger will add one more column, which will make mobile table browsing experience worse. Presence of more than five messengers will noticably deteriorate desktop browsing experience.

That said, feel free to create a fork with messaging services you'd like to compare.
