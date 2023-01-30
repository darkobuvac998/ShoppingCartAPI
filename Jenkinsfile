pipeline {
    agent none
    environment {
        DISABLE_AUTH = 'true'
        DB_ENGINE    = 'sqlite'
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
    }
    stages {
        stage('Test and Build'){
            agent {
                node {
                    label 'dotnet-agent'
                }
            }
            stages {
                stage('Test Build Agent Environemt'){
                    steps{
                        echo "Navigating to source code"
                        sh 'dotnet --info'
                    }
                }
                stage('Restore dotnet project'){
                    steps{
                        echo "Restore packages"
                        sh '''
                        docker ps -a
                        docker --version
                        '''
                    }
                }
                stage('Build dotnet project') {
                    steps {
                        echo "Building ShoppingCart.API.."
                        sh '''
                        '''
                    }
                }
                stage('Test') {
                    steps {
                        echo "Testing.."
                        sh '''
                        echo "doing test stuff.."
                        '''
                        sh '''

                        '''
                    }
                }
                stage('Deliver') {
                    steps {
                        echo 'Deliver....'
                        sh '''
                        echo "doing delivery stuff.."
                        '''
                        sh '''


                        '''
                    }
                }
            }
        }
        
    }
}
