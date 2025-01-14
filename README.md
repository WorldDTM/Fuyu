# 冬 Fuyu

A BSG games backend written in C#.

## Contribution

The project is still in it's infancy and there still much work to be done.
PRs are not accepted at this point in time unless discussed in advanced since
the ground work is not there yet. Sorry for the inconvenience!

See `Documentation/CONTRIBUTING.md` for more information on standards.

## Requirements

- .NET 8.0 SDK
- WebView 2 Runtime

### Supported IDEs

- Visual Studio Code
- Visual Studio 2022

### Supported games

**Game** | **Version**
-------- | ------------
EFT      | 0.15.5.133420
Arena    | none (yet)

## Setup

### Local project

1. `git clone https://github.com/project-fika/fuyu`
2. Visual Studio Code > Terminal > Run Task... > "dotnet: restore"

### Repository CI/CD

1. Github > Generate new PAT
   1. Go [here](https://github.com/settings/tokens/new)
      - note: `FUYU_WORKFLOWS`
      - permissions: `repo` (all), `workflow` (all)
   2. Once PAT is generated, copy the token to clipboard
2. Github > Repositories > Fuyu > Settings > Secrets > Actions
3. New repository secret
   - name: `FUYU_WORKFLOWS`
   - field: paste your token

## Build

Visual Studio Code > Terminal > Run Build Task...

## Test

Visual Studio Code > Terminal > Run Task... > Fuyu: Test

## License

(C) seionmoya, all rights reserved.

## FAQ

> What does Fuyu stand for? Why was it chosen?

It means "Winter" in Japanese. The next season after Autumn (Aki, 秋).
It's a reference that this is the next-in-line major architecture rework for
SPTarkov.

## Credits

Sorted alphabetically ascending.

**Author**   | **Reason**
------------ | ---------------------------
nexus4880    | Maintainer
seionmoya    | Project creator, maintainer
thespartapt  | Maintainer