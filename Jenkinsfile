pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo "Building.."
                sh '''
                echo "doing build stuff.."
                '''
                sh '''
                docker ps -a
                docker container prune
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
                docker ps
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
                '''
            }
        }
    }
}
