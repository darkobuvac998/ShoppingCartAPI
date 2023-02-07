def keepThisBuild() {
    currentBuild.setKeepLog(true)
    currentBuild.setDescription('Test Description')
}

def getShortCommitHash() {
    return sh(returnStdout: true, script: "git log -n 1 --pretty=format:'%h'").trim()
}

def getCommitAuthorName() {
    return sh(returnStdout: true, script: 'git show -s --pretty=%an').trim()
}

def getCommitAuthorEmail() {
    return sh(returnStdout: true, script: 'git show -s --pretty=%ae').trim()
}

def getChangeSet() {
    return sh(returnStdout: true, script: 'git diff-tree --no-commit-id --name-status -r HEAD').trim()
}

def getChangeLog() {
    return sh(returnStdout: true, script: "git log --date=short --pretty=format:'%ad %aN <%ae> %n%n%x09* %s%d%n%b'").trim()
}

def getCommitMessage() {
    return sh(script: 'git log -1 --pretty=%B', returnStdout: true).trim()
}

def getCurrentBranch () {
    return sh(
            script: 'git rev-parse --abbrev-ref HEAD',
            returnStdout: true
    ).trim()
}

def isPRMergeBuild() {
    return (env.BRANCH_NAME ==~ /^PR-\d+$/)
}

def notifyBuild(String buildStatus = 'STARTED') {
    // build status of null means successful
    buildStatus = buildStatus ?: 'SUCCESS'

    def branchName = getCurrentBranch()
    def shortCommitHash = getShortCommitHash()
    def changeAuthorName = getCommitAuthorName()
    def changeAuthorEmail = getCommitAuthorEmail()
    def changeSet = getChangeSet()
    def changeLog = getChangeLog()

    // Default values
    def colorName = 'RED'
    def colorCode = '#FF0000'
    def subject = "${buildStatus}: '${env.JOB_NAME} [${env.BUILD_NUMBER}]'" + branchName + ', ' + shortCommitHash
    def summary = "Started: Name:: ${env.JOB_NAME} \n " +
            "Build Number: ${env.BUILD_NUMBER} \n " +
            "Build URL: ${env.BUILD_URL} \n " +
            'Short Commit Hash: ' + shortCommitHash + ' \n ' +
            'Branch Name: ' + branchName + ' \n ' +
            'Change Author: ' + changeAuthorName + ' \n ' +
            'Change Author Email: ' + changeAuthorEmail + ' \n ' +
            'Change Set: ' + changeSet

    if (buildStatus == 'STARTED') {
        color = 'YELLOW'
        colorCode = '#FFFF00'
    } else if (buildStatus == 'SUCCESS') {
        color = 'GREEN'
        colorCode = '#00FF00'
    } else {
        color = 'RED'
        colorCode = '#FF0000'
    }

    echo(message: summary)

    return summary

}

def setGitEnvironmentVariables() {
    env.IMAGE_TAG = getCurrentBranch()
    env.GIT_BRANCH = getCurrentBranch()
    env.GIT_COMMIT_HASH = getShortCommitHash()
    env.GIT_COMMIT_AUTHOR = getCommitAuthorName()
    env.GIT_COMMIT_MESSAGE = getCommitMessage()
    env.GIT_COMMIT_AUTHOR_EMAIL = getCommitAuthorEmail()
    env.GIT_CHANGES = getChangeSet()
}

def notifySlack(String buildStatus = 'STARTED', String logs = '') {
    def commitHash = env.GIT_COMMIT_HASH
    def commitAuthor = env.GIT_COMMIT_AUTHOR
    def commitMessage = env.GIT_COMMIT_MESSAGE
    def authorEmail = env.GIT_COMMIT_AUTHOR_EMAIL
    def changes = env.GIT_CHANGES
    def buildNumber = env.BUILD_NUMBER
    def buildId = env.BUILD_ID
    def jenkinsUrl = env.JENKINS_URL
    def branch = env.GIT_BRANCH

    // Default values
    def colorCode = '#FF0000'
    def subject = "${buildStatus}: '${env.JOB_NAME} [${env.BUILD_NUMBER}]'" + branch + ', ' + shortCommitHash
    def message = """
        Build ${currentBuild.result} at ${new Date().format('dd-MM-yyyy HH:mm:ss')}
        Branch: ${branch}
        Author: ${commitAuthor}
        Author email: ${authorEmail}
        Commit message: ${commitMessage}
        Commit hash: ${commitHash}
        Build number: ${buildNumber}
        Build ID: ${buildId}
        Build status: ${currentBuild.result}
        Subject: ${subject}
        Jenkins URL: ${jenkinsUrl}
        Logs: ${logs}
    """

    if (buildStatus == 'STARTED') {
        colorCode = '#FFFF00'
    } else if (buildStatus == 'SUCCESS') {
        colorCode = '#00FF00'
    } else {
        colorCode = '#FF0000'
    }

    echo "${message}"
}

def collectFailureLogs(failedStages) {
    String logOutput = ''

    if (failedStages.size() > 0) {
    }

    for (failure in failedStages) {
        logOutput += "Failed stage: ${failure.name}\n"
        logOutput += 'Failure log:\n'
        failure.log.each {
            logLine -> logOutput += '${logLine}: \n'
        }
        logOutput += '\n'
    }

    return logOutput
}

def generateImageName() {
    def stage = "${currentBuild.currentStage.parent.name}"
    def imageName = "${env.IMAGE_PREFIX}${stage}${env.IMAGE_TAG}"
    return imageName.toLowerCase()
}
