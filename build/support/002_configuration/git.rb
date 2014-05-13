configs ={
  :git => {
    :provider => 'github',
    :user => 'intellisysmay2014',
    :remotes => %w/mabreu adnanjt juanmcastillo gadielreyes 040mike/,
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
