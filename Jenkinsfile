pipeline {
    agent {
        docker{
            image 'mcr.microsoft.com/dotnet/sdk:6.0-alpine'
        }
    }
    stages {
        stage('Test Build Agent Environemt'){
          steps{
            echo "Navigating to source code"
            sh '''
            dotnet --info
            '''
          }
        }
        stage('Build') {
            steps {
                echo "Building.."
                sh '''
                echo "doing build stuff.."
                '''
                sh '''
                docker ps -a
                docker container prune -f
                docker run -d --rm -d -p 8080:80 --name web nginx
                docker ps -a
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
                docker ps -a
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
                docker stop web
                docker ps -a
                '''
            }
        }
    }
}
