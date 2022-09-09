# Alter Ego

## Quick Links

 - Communication via [Discord](https://discord.gg/fKvweVH9CU)
 - Documentation (GDD, surveys, notes, etc.) on [Google Drive](https://drive.google.com/drive/folders/1wZfKsCMxFXs1D0v6773a8cE5PwrfDy2c?usp=sharing)
 - [Project board](https://github.com/vinayg-usc/alter-ego-game/projects) for tracking issues and progress

## Environment Setup

### Installation

 - Latest version of [git](https://git-scm.com/downloads). Make sure LFS option is checked when installing. 
 - [Unity Hub](https://unity3d.com/get-unity/download), and through that Unity. Ensure to select version `2021.3.8f1`, and enable WebGL deployment.
 - A merge tool for resolving conflicts. [VS Code](https://code.visualstudio.com/download) is a great option, or you can download your own.

### **Immediately after cloning**

#### Step 1: Basic git configuration

```bash
# Configure line endings to use LF across all platforms,
# to avoid unnecessary conflicts
git config --local core.autocrlf input

# Reset your cloned repository to fix the line-endings
git rm --cached -r .
git reset --hard

# Setup git LFS
git lfs install
```

#### Step 2: Configure [Unity Smart Merge](https://docs.unity3d.com/Manual/SmartMerge.html)

Locate your Unity installation, hence denoted as `UNITY_TOOLS_FOLDER`.
  - For example, on Windows it is `C:/Program Files/Unity/Hub/Editor/2021.3.8f1/Editor/Data/Tools/`
 - This folder has two files of interest:
   - `UnityYAMLMerge.exe`: The program that performs smart merge
   - `mergespecfile.txt`: Configuration of "fallback" merge tool for remaining conflicts

Open your local git config using: `git config --local --edit` and paste the following:
```conf
[merge]
    tool = unityyamlmerge
[mergetool "unityyamlmerge"]
    keepBackup = false
    trustExitCode = false
    cmd = \"<UNITY_TOOLS_FOLDER>/UnityYAMLMerge.exe\" merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```

Replace the contents of `mergespecfile.txt`, to setup your "fallback" merge tool. The below shows an example for VS Code:

```txt
#
# UnityYAMLMerge fallback file
#
# %l is replaced with the path of you local version
# %r is replaced with the path of the incoming remote version
# %b is replaced with the common base version
# %d is replaced with a path where the result should be written to
# On Windows %programs% is replaced with "C:\Program Files" and "C:\Program Files (x86)" there by resulting in two entries to try out
# On OSX %programs% is replaced with "/Applications" and "$HOME/Applications" thereby resulting in two entries to try out

* use "%programs%/Microsoft VS Code/bin/code" --wait --merge %r %l %b %d
```

If you are using SourceTree, you may want to check this [YouTube tutorial](https://youtu.be/P_vLYDq2YkE).

#### Test if Smart Merge works

Please see this [sample repository](https://github.com/vinayg-usc/unity-git-expt) created with a deliberate conflict, to help verify if your config works.

## Developer Guidelines (draft)

We will work in an Agile-like approach, using the tools integrated within GitHub for easy tracking. Please find the guidelines below, and feel free to share your thoughts on them!
 - We will try to divide work in a non-overlapping way.
 - Everything that can be a prefab, should be a prefab.
   - Once we have these "building blocks", we can create levels rapidly and indpendently.
 - TEST YOUR CHANGES before committing.
   - Let's create a "test" scene for each mechanic so we have full freedom to debug.
