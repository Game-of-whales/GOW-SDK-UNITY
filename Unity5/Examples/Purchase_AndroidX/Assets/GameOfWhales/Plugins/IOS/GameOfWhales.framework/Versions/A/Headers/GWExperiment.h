//
//  GWExperiment.h
//  GameOfWhales
//
//  Created by Denis Sachkov on 18/07/2019.
//  Copyright © 2019 GameOfWhales. All rights reserved.
//

#ifndef GWExperiment_h
#define GWExperiment_h

#import <Foundation/Foundation.h>

/*!
 @brief Special offer description
 */
@interface GWExperiment : NSObject

+ (nonnull instancetype)experimentWithJson:(nonnull NSDictionary *)json;
- (nonnull instancetype)initWithJson:(nullable NSDictionary *)json;

@property(nonatomic, nonnull) NSString *id;
@property(nonatomic, nonnull) NSString *key;
@property(nonatomic, nonnull) NSString *groupKey;
@property(nonatomic, nonnull) NSString *payload;
@property(nonatomic, nonnull) NSString *signature;

-(nonnull NSString*)save;
@end


#endif /* GWExperiment_h */
