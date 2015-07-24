//
//  TableProxy.m
//  ContosoUniversity
//
//  Created by Shrirang on 7/24/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#import "TableProxy.h"

@implementation TableProxy

@synthesize table = _table;

- (instancetype)initWithMobileAppClient:(MSClient *)client tableName:(NSString *)tableName {
   
    self = [super init];
    
    if (self) {
        _client = client;
        _table = [client tableWithName:tableName];
    }
    
    return self;
}

- (void)pullData:(MSSyncBlock)completion {
    [self.table readWithCompletion:^(MSQueryResult *result, NSError *error) {
        if (!error) {
            [self.client.syncContext.dataSource upsertItems:result.items table:@"Courses" orError:&error];
        }
        if (completion != nil) {
            completion(error);
        }
    }];
}

@end