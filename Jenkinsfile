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
                stage('Build dotnet project') {
                    steps {
                        echo "Building ShoppingCart.API.."
                        sh '''
                        pwd
                        cd ShoppingCart.API/ 
                        dotnet build "ShoppingCart.API.csproj" -c Release -o /bin
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
