#!groovy

pipeline{
    agent any
    options {
        buildDiscarder(logRotator(artifactDaysToKeepStr: '', artifactNumToKeepStr: '', daysToKeepStr: '1', numToKeepStr: '10'))
        timestamps()
        timeout time:10, unit:'MINUTES'
    }
    environment{
        BUILD_NUMBER = "${env.BUILD_NUMBER}"
        IMAGE_VERSION="v_${BUILD_NUMBER}"
        APP_NAME='ShoppingCartAPI'
        GIT_URL="git@github.com:darkobuvac998/${APP_NAME}.git"
    }
    parameters{
        string(defaultValue: "dev", description: 'Branch Specifier', name: 'SPECIFIER')
    }
    stages{

        stage('Test project and build docker image'){
            parallel{
                stage('Application'){
                    agent{
                        label "dotnet-agent"
                    }
                    stages{
                        stage('Initialize'){
                            steps{
                                script{
                                    notifyBuild('STARTED')
                                    echo "${BUILD_NUMBER} - ${env.BUILD_ID} on ${env.JENKINS_URL}"
                                    echo "Branch Specifier :: ${params.SPECIFIER}"
                                    sh 'rm -rf target/universal/*.zip'
                                }
                            }
                        }
                        stage('Restore packages'){
                            steps{
                                echo 'Run .NET dependency restorer'
                                sh 'dotnet restore "ShoppingCart.sln"'
                            }
                        }
                        stage('Build solution'){
                            steps{
                                echo 'Run dotnet build - Builds a project and all of its dependencies'
                                sh 'dotnet build "ShoppingCart.sln"'
                            }
                        }
                        stage('Run Unit Tests'){
                            steps{
                                echo 'Run dotnet test - '
                                sh '''
                                cd ShoppingCartAPI.UnitTests
                                dotnet test "ShoppingCartAPI.UnitTests.csproj"
                                cd ../
                                '''
                            }
                        }
                        stage('Publish Reports'){
                            steps{
                                echo 'Publish Junit Report'
                                junit allowEmptyResults: true, testResults: 'target/test-reports/*.xml'

                                echo(message: 'Publish Junit HTML Report')

                                publishHTML target: [
                                    allowMissing: true,
                                    alwaysLinkToLastBuild: false,
                                    keepAll: true,
                                    reportDir: 'target/reports/html',
                                    reportFiles: 'index.html',
                                    reportName: 'Test'
                                ]

                                echo 'Publish Coverage HTML Report'
                                publishHTML target: [
                                    allowMissing: true,
                                    alwaysLinkToLastBuild: false,
                                    keepAll: true,
                                    reportDir: 'target/scala-2.11/scoverage-report',
                                    reportFiles: 'index.html',
                                    reportName: 'Code Coverage'
                                ]

                                // whitesource jobApiToken: '', jobCheckPolicies: 'global', jobForceUpdate: 'global', libExcludes: '', libIncludes: '', product: "${env.WS_PRODUCT_TOKEN}", productVersion: '', projectToken: "${env.WS_PROJECT_TOKEN}", requesterEmail: ''

                            }
                        }

                    }
                }
                stage('Docker'){
                    agent{
                        label "docker-secondary"
                    }
                    stages{
                        stage('Build docker image'){
                            steps{
                                script{
                                    branchName = getCurrentBranch()
                                    shortCommitHash = getShortCommitHash()
                                    IMAGE_VERSION = "${BUILD_NUMBER}-" + branchName + "-" + shortCommitHash
                                    sh "docker ps"
                                    sh "docker build -t shopping-cart:${IMAGE_VERSION} -f docker/Dockerfile ."
                                    sh "docker image ls"
                                }
                            }
                        }
                    }
                }
            }
        }

    }
    post{
        always{
            echo "================ BUILD END ================"
            notifyBuild("${currentBuild.currentResult}")
        }
        success{
            echo "================ BUILD SUCCESS ================"
        }
        failure{
            echo "================ BUILD FAILURE ================"
        }
        aborted{
            echo "================ BUILD ABORTED ================"
        }
        unstable{
            echo "================ BUILD UNSTABLE TEST================"
        }
    }
}

def keepThisBuild() {
    currentBuild.setKeepLog(true)
    currentBuild.setDescription("Test Description")
}

def getShortCommitHash() {
    return sh(returnStdout: true, script: "git log -n 1 --pretty=format:'%h'").trim()
}

def getChangeAuthorName() {
    return sh(returnStdout: true, script: "git show -s --pretty=%an").trim()
}

def getChangeAuthorEmail() {
    return sh(returnStdout: true, script: "git show -s --pretty=%ae").trim()
}

def getChangeSet() {
    return sh(returnStdout: true, script: 'git diff-tree --no-commit-id --name-status -r HEAD').trim()
}

def getChangeLog() {
    return sh(returnStdout: true, script: "git log --date=short --pretty=format:'%ad %aN <%ae> %n%n%x09* %s%d%n%b'").trim()
}

def getCurrentBranch () {
    return sh (
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
    def changeAuthorName = getChangeAuthorName()
    def changeAuthorEmail = getChangeAuthorEmail()
    def changeSet = getChangeSet()
    def changeLog = getChangeLog()

    // Default values
    def colorName = 'RED'
    def colorCode = '#FF0000'
    def subject = "${buildStatus}: '${env.JOB_NAME} [${env.BUILD_NUMBER}]'" + branchName + ", " + shortCommitHash
    def summary = "Started: Name:: ${env.JOB_NAME} \n " +
            "Build Number: ${env.BUILD_NUMBER} \n " +
            "Build URL: ${env.BUILD_URL} \n " +
            "Short Commit Hash: " + shortCommitHash + " \n " +
            "Branch Name: " + branchName + " \n " +
            "Change Author: " + changeAuthorName + " \n " +
            "Change Author Email: " + changeAuthorEmail + " \n " +
            "Change Set: " + changeSet

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
    
    // Send notifications
    // hipchatSend(color: color, notify: true, message: summary, token: "${env.HIPCHAT_TOKEN}",
    //     failOnError: true, room: "${env.HIPCHAT_ROOM}", sendAs: 'Jenkins', textFormat: true)

    // if (buildStatus == 'FAILURE') {
    //     emailext attachLog: true, body: summary, compressLog: true, recipientProviders: [brokenTestsSuspects(), brokenBuildSuspects(), culprits()], replyTo: 'noreply@yourdomain.com', subject: subject, to: 'mpatel@yourdomain.com'
    // }
}