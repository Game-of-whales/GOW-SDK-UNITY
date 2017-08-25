//
//  GWSpecialOffer.h
//  GameOfWhales
//
//  Created by Denis Sachkov on 05.07.17.
//  Copyright © 2017 GameOfWhales. All rights reserved.
//

#import <Foundation/Foundation.h>


@interface GWSpecialOffer : NSObject

@property(nonatomic, nonnull) NSString *campaign;
@property(nonatomic, nonnull) NSString *product;
@property(nonatomic) float priceFactor;
@property(nonatomic) float countFactor;
@property(nonatomic) bool redeemable;
@property(nonatomic, nonnull) NSDate* finishedAt;
@property(nonatomic, nonnull) NSString *payload;

- (BOOL)isExpired;
-(bool)hasPriceFactor;
-(bool)hasCountFactor;
@end



